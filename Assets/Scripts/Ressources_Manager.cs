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

    [Header("Ingredients")]
    //Valeurs Ressources
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
    private float f_stockCadenceInitial;

    [Header("Ingredients Stock Limit")]
    public int i_flourStockLimit;
    public int i_milkStockLimit;
    public int i_eggStockLimit;
    public int i_chocolateStockLimit;

    void Start()
    {
        f_cookieCadenceInitial = f_cookieCadence;
        f_stockCadenceInitial = f_stockCadence;
        //f_ressourcesCadenceInitial = f_ressourcesCadence;
    }

    void Update()
    {
        f_cookieCadence -= Time.deltaTime;
        f_stockCadence -= Time.deltaTime;
        //f_ressourcesCadence -= Time.deltaTime;

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

        if (f_stockCadence <= 0)
        {
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

            f_stockCadence = f_stockCadenceInitial;
        }

        //Add Cookie per second
        if (Input.GetKeyDown(KeyCode.Y))
        {
            AddCookiePerSecond(1);
        }

        //Add Ingredients
        if (Input.GetKeyDown(KeyCode.U))
        {
            AddFlour(10);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            AddMilk(10);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            AddEgg(10);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddChocolate(10);
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
    void AddCookiePerSecond(int addCookiePerSecond)
    {
        i_cookiePerSecond += addCookiePerSecond;
    }

    //Functions Add Ingredients
    void AddFlour(int addFlour)
    {
        i_flour += addFlour;
    }
    void AddMilk(int addMilk)
    {
        i_milk += addMilk;
    }
    void AddEgg(int addEgg)
    {
        i_egg += addEgg;
    }
    void AddChocolate(int addChocolate)
    {
        i_chocolate += addChocolate;
    }

    //Function Add Ingredients per second in stock
    void AddFlourStockPerSecond(int addFlourPerSecond)
    {
        i_flourStockPerSecond += addFlourPerSecond;
    }
    void AddMilkStockPerSecond(int addMilkPerSecond)
    {
        i_milkStockPerSecond += addMilkPerSecond;
    }
    void AddEggStockPerSecond(int addEggPerSecond)
    {
        i_eggStockPerSecond += addEggPerSecond;
    }
    void AddChocolateStockPerSecond(int addChocolatePerSecond)
    {
        i_chocolateStockPerSecond += addChocolatePerSecond;
    }

}
