using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private List<ShopItem> items=new List<ShopItem>();
    public GameObject[] buyEquipment, chooseEquipment;

    public Image[] itemBgs;

    public Color32 bought, chosen, availablle;
    public Text[] prices;

    //public ParticleSystem buyEffect;

    public Text coinsCurrent;

    void Start(){
        coinsCurrent.text=PlayerPrefs.GetInt("coins").ToString();

        items.Add(new ShopItem(0,000,"Default"));
        items.Add(new ShopItem(1,400,"Orange"));
        items.Add(new ShopItem(2,650,"Red"));
        items.Add(new ShopItem(3,850,"Transparent"));
        items.Add(new ShopItem(4,1250,"Shinny"));

        for(int i=0;i<items.Count;i++){
            prices[i].text=items[i].price.ToString();
        }

        showAvailable();
    }

    public void choose(int id){
        if(PlayerPrefs.GetInt("Car@"+id.ToString())==1 || id == 0){
            PlayerPrefs.SetInt("current",id);
        }

        showAvailable();
    }


    public void showAvailable(){
        for(int i=0;i<items.Count;i++){
            if(PlayerPrefs.GetInt("current") == i){
                chooseEquipment[i].SetActive(false);
                buyEquipment[i].SetActive(false);

                itemBgs[i].GetComponent<Image>().color = chosen;
            }else{
                if(PlayerPrefs.GetInt("Car@"+i.ToString())==1 || i == 0){
                    buyEquipment[i].SetActive(false);
                    chooseEquipment[i].SetActive(true);

                    itemBgs[i].GetComponent<Image>().color = bought;
                }
                else{
                    buyEquipment[i].SetActive(true);
                    chooseEquipment[i].SetActive(false);

                    itemBgs[i].GetComponent<Image>().color = availablle;
                }
            }
        }
    }

    public void buy(int id){
        if(PlayerPrefs.GetInt("coins")>=items[id].price){
            PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")-items[id].price);

            items[id].buy();

            //buyEffect.Play();
            coinsCurrent.text=PlayerPrefs.GetInt("coins").ToString();

            showAvailable();
        }
    }
}
