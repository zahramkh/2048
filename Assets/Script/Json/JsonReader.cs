using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using System;
using Newtonsoft.Json.Linq;

public class JsonReader  :MonoBehaviour
{
    [TextArea(1,5)]
    public string json;

    [Serializable]
    public class Rewards
    {
        public int type;
        public int amount;
    }

    [Serializable]
    public class Bundles
    {
        public bool sale;
        public int type;
        public int label;
        public int price;
        public int iconId;
        public bool oneTime;
        public Rewards[] rewards;
        public string productId;
        public int firstOrder;
        public string packageName;
        public string priceString;
        public int secondOrder;
        public int offCoinAmount;
        public int offPercentage;
        public Rewards additionalReward;
        public string persistentDataKey;

        //public Bundles(bool sale, int type, int label, int price, int iconId, bool oneTime, Rewards[] rewards, string productId, int firstOrder, string packageName, string priceString, int secondOrder, int offCoinAmount, int offPercentage, Rewards additionalReward, string persistentDataKey)
        //{
        //    this.sale = sale;
        //    this.type = type;
        //    this.label = label;
        //    this.price = price;
        //    this.iconId = iconId;
        //    this.oneTime = oneTime;
        //    this.rewards = rewards;
        //    this.productId = productId;
        //    this.firstOrder = firstOrder;
        //    this.packageName = packageName;
        //    this.priceString = priceString;
        //    this.secondOrder = secondOrder;
        //    this.offCoinAmount = offCoinAmount;
        //    this.offPercentage = offPercentage;
        //    this.additionalReward = additionalReward;
        //    this.persistentDataKey = persistentDataKey;
        //}
    }

    public List<Bundles> bundles= new List<Bundles>();
    
    void Start()
    {
        //var Example=new Bundles(false, 1, 2, 3, 4, true, [5, 10], "e", 1, "r", 4, 4, 4,{ 1,2},"i");
        JObject jsonObject = JObject.Parse(json);
        JToken valueToken = jsonObject["value"];
        JToken bundlesToken = valueToken["bundles"];

        bundles = bundlesToken.ToObject<List<Bundles>>();
     
    }
}
