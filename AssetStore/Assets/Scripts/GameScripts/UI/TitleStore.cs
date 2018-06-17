using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleStore : MonoBehaviour {

	public Text ObjectName;
    public Text Price;

    public int PRICE_INDEX = 5;
   public void init(TileObject tile,bool isItem)
    {
        ObjectName.text = tile.Name ?? "";

        gameObject.transform.GetComponentInChildren<StoreTailController>().init(tile);
        if (isItem)
        {
            Price.text = (tile as Item).ItemValueSum* PRICE_INDEX+"@";

        }
        else
        {
           
            Price.text =( tile as Character).SkillValueSum * PRICE_INDEX + "@";
        }



    }


}
