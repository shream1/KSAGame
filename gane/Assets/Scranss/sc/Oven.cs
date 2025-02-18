using UnityEngine;

public class Oven : MonoBehaviour
{
    public void CookFood(Food food)
    {
        food.StartCooking(); // بدء الطهي للطعام
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Food food = other.GetComponent<Food>();
            if (food != null)
            {
                CookFood(food);
            }
        }
    }
}