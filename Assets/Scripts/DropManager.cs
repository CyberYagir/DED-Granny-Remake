using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropManager : MonoBehaviour {
    public Shkaf[] AllShkafs;
    public Item[] List;
    public Text Debug;


    void Start()
    {
        Check();
    }
    public void Check()
    {
        while ((List[0].Spawned == false) || (List[1].Spawned == false) || (List[2].Spawned == false) || (List[3].Spawned == false)) { 
        for (int i = 0; i < List.Length; i++)
        {
                if (List[i].Spawned == false)
                {
                    int g = Random.Range(0, AllShkafs.Length);
                    if (AllShkafs[g].Drop == null)
                    {
                        AllShkafs[g].Drop = List[i].SomeItem;
                        Debug.text = Debug.text + "\n" + "Item:" + List[i].SomeItem.name + "-Shkaf:" + AllShkafs[g].name;
                        List[i].Spawned = true;
                    }
                }
            }
        }
    }

    [System.Serializable]
    public class Item
    {
        public GameObject SomeItem;
        public bool Spawned;
    }
}
