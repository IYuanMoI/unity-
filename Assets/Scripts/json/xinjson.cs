using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class MgrJson 
{
    private static MgrJson mj=new MgrJson();
    public static  MgrJson Mj 
    {
        get { return mj; }
    }
    private MgrJson() { }
    public string filePath = Application.persistentDataPath + "/Data/JsonData";

    /// <summary>
    /// �洢
    /// </summary>
    /// <param name="data">Ҫ�洢�Ķ���</param>
    /// <param name="path">�ļ���ǰ���·�� ֱ��filePath�Ǳ� ��ͷҪ��/</param>
    /// <param name="fileName">�ļ��� ��ͷҪ��/</param>
    public void Save(object data, string path, string fileName)
    {
        if (!Directory.Exists(filePath + path))
        Directory.CreateDirectory(filePath + path);

        File.WriteAllText(filePath + path + fileName + ".Json", JsonConvert.SerializeObject(data, Formatting.Indented));
    }

    /// <summary>
    /// ���ݶ�ȡ
    /// </summary>
    /// <typeparam name="T">��ȡ�����ݵ�����</typeparam>
    /// <param name="path">�ļ���ǰ���·�� ֱ��filePath�Ǳ� ��ͷҪ��/</param>
    /// <param name="fileName">�ļ��� ��ͷҪ��/</param>
    /// <returns></returns>
    public T Load<T>(string path, string fileName) where T : class, new()
    {
        if (!Directory.Exists(filePath + path))
            Directory.CreateDirectory(filePath + path);

        if (!File.Exists(filePath + path + fileName + ".Json"))
        {
            return new T();
        }

        return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath + path + fileName + ".Json"));
    }
}
