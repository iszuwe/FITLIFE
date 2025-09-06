using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "NewFoodItem", menuName = "Food/Food Item")]
//public class FoodItem : ScriptableObject
//{
//    public string foodName;
//    public string description;
//    public Sprite icon;
//    public enum FoodType { Healthy, Junk }
//    public FoodType foodType;

//    public float hungerChange;
//    public float healthChange;
//    public float dietChange;
//}
[CreateAssetMenu(fileName = "New Food", menuName = "Food/Food Item")]
public class FoodItem : ScriptableObject
{
    public string foodName;
    public Sprite icon;
    public string description;
    public int healthValue;
    public int dietValue;
    public int satietyValue;

    public int price;
}