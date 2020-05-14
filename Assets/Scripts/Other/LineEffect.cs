using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEffect : MonoBehaviour
{
    //public GameObject LineRenderGameObject;//GameObject空物体
    public LineRenderer lineRender;//GameObject的lineRenderer组件
    //private int lineLength = 4;//顶点数量
                               //3D空间中的4个点
    public Vector3 v0 = new Vector3(1, 1, 0);
    public Vector3 v1 = new Vector3(2, 2, 0);
    public Vector3 v2 = new Vector3(3, 2, 0);
    public Vector3 v3 = new Vector3(4, 1, 0);

    void Start()
    {
        //LineRenderGameObject = GameObject.Find("GameObject");//获取GameObject物体
        //lineRender = GetComponent<LineRenderer>() as LineRenderer;//获取组件
        ///lineRender.SetVertexCount(lineLength);//设置顶点数量
        ///lineRender.SetWidth(0.1f, 0.1f);//设置宽度
    }

    void Update()
    {
        //设置顶点顺序，位置
        lineRender.SetPosition(0, v0);
        lineRender.SetPosition(1, v1);
        lineRender.SetPosition(2, v2);
        lineRender.SetPosition(3, v3);
    }

}
