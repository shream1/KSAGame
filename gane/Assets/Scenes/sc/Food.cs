using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables; // Import Playables namespace

public enum FoodState
{
    Raw,
    Cooked,
    Burnt
}

public class Food : MonoBehaviour
{
    public float cookingTime = 5f; // Time to cook the food
    public float burnTime = 10f; // Time after which the food burns
    private float cookTimer;
    private bool isCooking = false;
    private FoodState currentState = FoodState.Raw;

    public Renderer foodRenderer; // Renderer component for the food
    public Material rawMaterial; // Material for raw food
    public Material cookedMaterial; // Material for cooked food
    public Material burntMaterial; // Material for burnt food

    public UnityEvent onCooked; // Event when the food is cooked
    public UnityEvent onBurnt; // Event when the food is burnt

    public PlayableDirector cookedTimeline; // Reference to the cooked timeline
    public PlayableDirector burntTimeline; // Reference to the burnt timeline

    void Update()
    {
        if (isCooking)
        {
            cookTimer -= Time.deltaTime;

            if (cookTimer <= 0)
            {
                if (currentState == FoodState.Raw)
                {
                    currentState = FoodState.Cooked;
                    foodRenderer.material = cookedMaterial; // Change material to cooked
                    onCooked.Invoke(); // Invoke cooked event
                    cookedTimeline.Play(); // Play cooked timeline
                    Debug.Log("Food is cooked!");
                }
            }

            if (currentState == FoodState.Cooked && cookTimer <= -burnTime)
            {
                currentState = FoodState.Burnt;
                foodRenderer.material = burntMaterial; // Change material to burnt
                onBurnt.Invoke(); // Invoke burnt event
                burntTimeline.Play(); // Play burnt timeline
                Debug.Log("Food is burnt!");
                isCooking = false;
            }
        }
    }

    public void StartCooking()
    {
        if (currentState == FoodState.Raw)
        {
            isCooking = true;
            cookTimer = cookingTime; // Set the cooking timer
            foodRenderer.material = rawMaterial; // Change material to raw
            Debug.Log("Cooking started!");
        }
    }

    public void ResetFood()
    {
        isCooking = false;
        currentState = FoodState.Raw;
        foodRenderer.material = rawMaterial; // Reset material to raw
        Debug.Log("Food reset.");
    }

    public FoodState GetCurrentState()
    {
        return currentState; // Return the current state of the food
    }
}