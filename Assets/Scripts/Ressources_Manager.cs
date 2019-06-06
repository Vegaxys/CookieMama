using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressources_Manager : MonoBehaviour
{
    [Header("Cookie Numbers")]
    public int i_cookieTotal;
    public int i_cookie;
    public int i_cookiePerSecond;

    [Header("Timer cookie")]
    public float f_cookieCadence;
    private float f_cookieCadenceInitial;

    //Valeurs Ressources
    [Header("Ingredients")]
    public int i_flour;
    public int i_milk;
    public int i_egg;
    public int i_chocolate;

    [Header("Ingredients stock")]
    public int i_flourStock;
    public int i_milkStock;
    public int i_eggStock;
    public int i_chocolateStock;

    [Header("Ingredients stock per second")]
    public int i_flourStockPerSecond;
    public int i_milkStockPerSecond;
    public int i_eggStockPerSecond;
    public int i_chocolateStockPerSecond;

    [Header("Timer stock")]
    public float f_stockCadence;

    [Header("Ingredients Stock Limit")]
    public int i_flourStockLimit;
    public int i_milkStockLimit;
    public int i_eggStockLimit;
    public int i_chocolateStockLimit;

    [Header("Ingredients on Player")]
    public int i_flourPlayer;
    public int i_milkPlayer;
    public int i_eggPlayer;
    public int i_chocolatePlayer;

    #region Singleton(enfin, c'est pas un vrai)
    public static Ressources_Manager ressourcesManager;
    private void Awake() {
        ressourcesManager = this;
    }
    #endregion

    void Start()
    {
        f_cookieCadenceInitial = f_cookieCadence;

        StartCoroutine(AddIngredientStock());
    }

    void Update()
    {
        f_cookieCadence -= Time.deltaTime;

        //Recipe Cookie
        if (i_chocolate >= 1 && i_flour >= 2 && i_milk >= 3 && i_egg >= 4)
        {
            if (f_cookieCadence <= 0)
            {
                //f_cookie += 1;
                i_cookie += CreateCookie(1, 2, 3, 4);
                i_cookieTotal += CreateCookie(0, 0, 0, 0);

                f_cookieCadence = f_cookieCadenceInitial;
            }
        }

        //Stock Limit
        if(i_flourStock >= i_flourStockLimit)
        {
            i_flourStock = i_flourStockLimit;
        }
        if (i_milkStock >= i_milkStockLimit)
        {
            i_milkStock = i_milkStockLimit;
        }
        if (i_eggStock >= i_eggStockLimit)
        {
            i_eggStock = i_eggStockLimit;
        }
        if (i_chocolateStock >= i_chocolateStockLimit)
        {
            i_chocolateStock = i_chocolateStockLimit;
        }
        #region Inputs
        //Add Cookie per second
        if (Input.GetKeyDown(KeyCode.Y))
        {
            AddCookiePerSecond(1);
        }

        //Add Ingredients
        if (Input.GetKeyDown(KeyCode.U))
        {
            AddFlour(i_flourPlayer);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            AddMilk(i_milkPlayer);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            AddEgg(i_eggPlayer);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddChocolate(i_chocolatePlayer);
        }

        //Add Ingredients per second in stock
        if (Input.GetKeyDown(KeyCode.J))
        {
            AddFlourStockPerSecond(5);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddMilkStockPerSecond(5);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            AddEggStockPerSecond(5);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddChocolateStockPerSecond(5);
        }

        //Add stock limits
        if (Input.GetKeyDown(KeyCode.N))
        {
            AddFlourStockLimit(10);
        }
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            AddMilkStockLimit(10);
        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            AddEggStockLimit(10);
        }
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            AddChocolateStockLimit(10);
        }

        //Take ingredient from stock
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            TakeFlour(i_flourStock);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            TakeMilk(i_milkStock);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            TakeEgg(i_eggStock);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            TakeChocolate(i_chocolateStock);
        }
        #endregion
    }

    //Every second, Add ingredient in stock
    IEnumerator AddIngredientStock()
    {
        yield return new WaitForSeconds(f_stockCadence);

        if (i_flourStock <= i_flourStockLimit)
        {
            i_flourStock += i_flourStockPerSecond;
        }
        if (i_milkStock <= i_milkStockLimit)
        {
            i_milkStock += i_milkStockPerSecond;
        }
        if (i_eggStock <= i_eggStockLimit)
        {
            i_eggStock += i_eggStockPerSecond;
        }
        if (i_chocolateStock <= i_chocolateStockLimit)
        {
            i_chocolateStock += i_chocolateStockPerSecond;
        }

        StartCoroutine(AddIngredientStock());
    }

    int CreateCookie(int flour, int milk, int egg, int chocolate)
    {
        int cookie = i_cookiePerSecond;

        i_flour -= flour;
        i_milk -= milk;
        i_egg -= egg;
        i_chocolate -= chocolate;

        return cookie;
    }

    //Function Add Cookie per second
    public void AddCookiePerSecond(int addCookiePerSecond)
    {
        i_cookiePerSecond += addCookiePerSecond;
    }

    //Functions Add Ingredients
    public void AddFlour(int addFlour)
    {
        i_flour += addFlour;
        i_flourPlayer -= i_flourPlayer;
    }
    public void AddMilk(int addMilk)
    {
        i_milk += addMilk;
        i_milkPlayer -= i_milkPlayer;
    }
    public void AddEgg(int addEgg)
    {
        i_egg += addEgg;
        i_eggPlayer -= i_eggPlayer;
    }
    public void AddChocolate(int addChocolate)
    {
        i_chocolate += addChocolate;
        i_chocolatePlayer -= i_chocolatePlayer;
    }

    //Function Add Ingredients per second in stock
    public void AddFlourStockPerSecond(int addFlourPerSecond)
    {
        i_flourStockPerSecond += addFlourPerSecond;
    }
    public void AddMilkStockPerSecond(int addMilkPerSecond)
    {
        i_milkStockPerSecond += addMilkPerSecond;
    }
    public void AddEggStockPerSecond(int addEggPerSecond)
    {
        i_eggStockPerSecond += addEggPerSecond;
    }
    public void AddChocolateStockPerSecond(int addChocolatePerSecond)
    {
        i_chocolateStockPerSecond += addChocolatePerSecond;
    }

    //Function Add Stock limits
    public void AddFlourStockLimit(int addFlourStockLimit)
    {
        i_flourStockLimit += addFlourStockLimit;
    }
    public void AddMilkStockLimit(int addMilkStockLimit)
    {
        i_milkStockLimit += addMilkStockLimit;
    }
    public void AddEggStockLimit(int addEggStockLimit)
    {
        i_eggStockLimit += addEggStockLimit;
    }
    public void AddChocolateStockLimit(int addChocolateStockLimit)
    {
        i_chocolateStockLimit += addChocolateStockLimit;
    }

    //Function Take from stock
    public void TakeFlour(int stockFlour)
    {
        i_flourPlayer += stockFlour;
        i_flourStock -= i_flourStock;
    }
    public void TakeMilk(int stockMilk)
    {
        i_milkPlayer += stockMilk;
        i_milkStock -= i_milkStock;
    }
    public void TakeEgg(int stockEgg)
    {
        i_eggPlayer += stockEgg;
        i_eggStock -= i_eggStock;
    }
    public void TakeChocolate(int stockChocolate)
    {
        i_chocolatePlayer += stockChocolate;
        i_chocolateStock -= i_chocolateStock;
    }
}
