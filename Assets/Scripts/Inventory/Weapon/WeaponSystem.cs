using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class WeaponSystem
{
    public WeaponSystem(){ }
    /// <summary>
    /// 使用Index获取武器名字
    /// </summary>
    public int weaponIndex;
    /// <summary>
    /// 当前手持武器
    /// </summary>
    public IWeapon currentWeapon;
    /// <summary>
    /// 存储已实例的武器
    /// </summary>
    public Dictionary<string, IWeapon> weaponDic = new Dictionary<string, IWeapon>();
    /// <summary>
    /// 存储武器名字，可以根据名字获取WeaponIndex，或者根据WeaponIndex获取武器名字
    /// </summary>
    private List<string> weaponName = new List<string>();
    /// <summary>
    /// 解析Json，实例化武器
    /// </summary>
    /// <param name="WeaponName"></param>
    /// <returns></returns>
    public  IWeapon GetWeapon(string _weaponName)
    {
        //判断武器是否实例过，是的话直接取出
        if(weaponDic.ContainsKey(_weaponName))
        {
            int index = 0;
            foreach(string str in weaponName)
            {
                index++;
                if (str == _weaponName) break;
            }
            weaponIndex = index;
            currentWeapon.gunObject.SetActive(false);
            currentWeapon = weaponDic[_weaponName];
            currentWeapon.gunObject.SetActive(true);
            return currentWeapon;
        }
        //没有实例过的话进行加载实例
        TextAsset itemText = Resources.Load<TextAsset>("Weapon");
        string weaponJson = itemText.text;
        JsonData jsonData = JsonMapper.ToObject(weaponJson);
        int id = (int)jsonData[_weaponName]["ID"];
        string name = jsonData[_weaponName]["Name"].ToString();
        string type = jsonData[_weaponName]["Type"].ToString();
        string path = jsonData[_weaponName]["Path"].ToString();
        string iconPath = jsonData[_weaponName]["IconPath"].ToString();
        string description = jsonData[_weaponName]["Description"].ToString();
        int capacity = (int)jsonData[_weaponName]["Capacity"];
        int damage = (int)jsonData[_weaponName]["Damage"];
        int elastance = (int)jsonData[_weaponName]["Elastance"];
        int maxElastance = (int)jsonData[_weaponName]["MaxElastance"];
        int buyPrice = (int)jsonData[_weaponName]["BuyPrice"];
        string muzzleEffectPath = jsonData[_weaponName]["MuzzleEffectPath"].ToString();
        string explodeEffectPath = jsonData[_weaponName]["ExplodeEffectPath"].ToString();
        string bulletPath = jsonData[_weaponName]["BulletPath"].ToString();
        int attackFrequency = (int)jsonData[_weaponName]["AttackFrequency"];
        switch (_weaponName)
        {            

            case "Pistol":
                weaponDic.Add(_weaponName, new Pistol(id, name, type, path, iconPath, description, capacity, damage, elastance, maxElastance, buyPrice, muzzleEffectPath, explodeEffectPath, bulletPath, attackFrequency));
                break;
            case "Rifle":
                weaponDic.Add(_weaponName, new Rifle(id, name, type, path, iconPath, description, capacity, damage, elastance, maxElastance, buyPrice, muzzleEffectPath, explodeEffectPath, bulletPath, attackFrequency));
                break;
            case "Automica":
                weaponDic.Add(_weaponName, new Automica(id, name, type, path, iconPath, description, capacity, damage, elastance, maxElastance, buyPrice, muzzleEffectPath, explodeEffectPath, bulletPath, attackFrequency));
                break;
            case "Submachine":
                weaponDic.Add(_weaponName, new Submachine(id, name, type, path, iconPath, description, capacity, damage, elastance, maxElastance, buyPrice, muzzleEffectPath, explodeEffectPath, bulletPath, attackFrequency));
                break;
            case "Bang":
                weaponDic.Add(_weaponName, new Bang(id, name, type, path, iconPath, description, capacity, damage, elastance, maxElastance, buyPrice, muzzleEffectPath, explodeEffectPath, bulletPath, attackFrequency));
                break;
            case "Laser":
                weaponDic.Add(_weaponName, new Laser(id, name, type, path, iconPath, description, capacity, damage, elastance, maxElastance, buyPrice, muzzleEffectPath, explodeEffectPath, bulletPath, attackFrequency));
                break;
            default:
                Debug.LogError("找不到正确的武器");
                return null;
        }
        if(weaponDic.Count>1)
        {
            currentWeapon.gunObject.SetActive(false);

        }
        weaponName.Add(_weaponName);
        currentWeapon = weaponDic[_weaponName];
        weaponIndex = weaponDic.Count-1;
        return currentWeapon;
    }
    /// <summary>
    /// 获取武器
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public IWeapon GetWeapon(int index)
    {
        //Debug.Log("传进来的Index = " + index);
        //Debug.Log("使用滚轮切换武器");
        if (index > weaponDic.Count-1)
        {
            //Debug.Log("武器到顶了");
            weaponIndex = weaponDic.Count-1;
            return currentWeapon;
        }
        if (index < 0)
        {
            //Debug.Log("武器到尾了");
            weaponIndex = 0;
            return currentWeapon;
        }
        currentWeapon.gunObject.SetActive(false);
        weaponIndex = index;
        //Debug.Log("武器的Index = " + weaponIndex);

        currentWeapon = weaponDic[weaponName[index]];
        currentWeapon.gunObject.SetActive(true);
        return currentWeapon;        
    }

    public int GetWeaponPrice(string weaponName)
    {
        TextAsset itemText = Resources.Load<TextAsset>("Weapon");
        string weaponJson = itemText.text;
        JsonData jsonData = JsonMapper.ToObject(weaponJson);
        int buyPrice = (int)jsonData[weaponName]["BuyPrice"];
        return buyPrice;
    }
}
