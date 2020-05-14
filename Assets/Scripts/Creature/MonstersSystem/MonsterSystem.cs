using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSystem
{

    public List<IMonster> monsters = new List<IMonster>();

    public void Update()
    {
        for(int i = 0;i<=monsters.Count-1;i++)
        {
            monsters[i].Update();
        }
    }

}
