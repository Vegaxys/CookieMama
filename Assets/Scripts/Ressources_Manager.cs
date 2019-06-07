using System.Collections;
using UnityEngine;

public class Ressources_Manager : MonoBehaviour
{
    #region Variables
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

    [Header("Upgrades Prices")]
    public int i_upgradePrice;

    [Header("Sounds")]
    public AudioSource upgrade;
    public AudioSource upgrade_cookie;
    #endregion

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
                int _cookie = CreateCookie(1, 2, 3, 4);
                i_cookie += _cookie;
                i_cookieTotal += _cookie;

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

        if (Input.GetKeyDown(KeyCode.U))
        {
            AddFlour();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            AddMilk();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            AddEgg();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddChocolate();
        }

        //Upgrades
        if (i_cookie >= i_upgradePrice)
        {
            //Add Cookie per second
            if (Input.GetKeyDown(KeyCode.Y))
            {
                AddCookiePerSecond(1);
            }

            //Add Ingredients per second in stock
            if (Input.GetKeyDown(KeyCode.J))
            {
                AddFlourStockPerSecond();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                AddMilkStockPerSecond();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                AddEggStockPerSecond();
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                AddChocolateStockPerSecond();
            }

            //Add stock limits
            if (Input.GetKeyDown(KeyCode.N))
            {
                AddFlourStockLimit();
            }
            if (Input.GetKeyDown(KeyCode.Comma))
            {
                AddMilkStockLimit();
            }
            if (Input.GetKeyDown(KeyCode.Period))
            {
                AddEggStockLimit();
            }
            if (Input.GetKeyDown(KeyCode.Slash))
            {
                AddChocolateStockLimit();
            }
        }

        //Take ingredient from stock
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            TakeFlour();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            TakeMilk();
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            TakeEgg();
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            TakeChocolate();
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

        i_flour -= i_flour / 100;
        i_milk -= i_milk / 100;
        i_egg -= i_egg / 100;
        i_chocolate -= i_chocolate / 100;

        return cookie;
    }

    //Function Add Cookie per second
    public void AddCookiePerSecond(int addCookiePerSecond)
    {
        if (!TestCookie())
            return;

        i_cookiePerSecond += addCookiePerSecond;
        i_cookiePerSecond += i_cookieTotal / 100;

        i_cookie -= i_upgradePrice;
        i_upgradePrice = i_upgradePrice + i_upgradePrice / 10;

        upgrade_cookie.Play();
}

    #region AddIngredients
    //Functions Add Ingredients
    public void GiveToMammy() {
        AddFlour();
        AddMilk();
        AddEgg();
        AddChocolate();
    }
    private void AddFlour()
    {
        i_flour += i_flourPlayer;
        i_flourPlayer = 0;
    }
    private void AddMilk()
    {
        i_milk += i_milkPlayer;
        i_milkPlayer = 0;
    }
    private void AddEgg()
    {
        i_egg += i_eggPlayer;
        i_eggPlayer = 0;
    }
    private void AddChocolate()
    {
        i_chocolate += i_chocolatePlayer;
        i_chocolatePlayer = 0;
    }
    #endregion

    #region Add Ingredient per second
    //Function Add Ingredients per second in stock
    public void AddFlourStockPerSecond()
    {
        if (!TestCookie())
            return;

        i_flourStockPerSecond += (i_cookieTotal / 100) + 5;
        i_cookie -= i_upgradePrice;
        i_upgradePrice = i_upgradePrice + i_upgradePrice / 10;

        upgrade.Play();
    }
    public void AddMilkStockPerSecond()
    {
        if (!TestCookie())
            return;

        i_milkStockPerSecond += (i_cookieTotal / 100) + 5;
        i_cookie -= i_upgradePrice;
        i_upgradePrice = i_upgradePrice + i_upgradePrice / 10;

        upgrade.Play();
    }
    public void AddEggStockPerSecond()
    {
        if (!TestCookie())
            return;

        i_eggStockPerSecond += (i_cookieTotal / 100) + 5;
        i_cookie -= i_upgradePrice;
        i_upgradePrice = i_upgradePrice + i_upgradePrice / 10;

        upgrade.Play();
    }
    public void AddChocolateStockPerSecond()
    {
        if (!TestCookie())
            return;

        i_chocolateStockPerSecond += (i_cookieTotal / 100) + 5;
        i_cookie -= i_upgradePrice;
        i_upgradePrice = i_upgradePrice + i_upgradePrice / 10;

        upgrade.Play();
    }
    #endregion

    bool TestCookie() {
        bool result = false;
        result = (i_cookie >= i_upgradePrice);
        return result;
}

    #region Add Stock Limit
    //Function Add Stock limits
    public void AddFlourStockLimit()
    {
        if (!TestCookie())
            return;

        i_flourStockLimit += (i_cookieTotal / 100) + 10;
        i_flourStockLimit += i_cookieTotal / 100;
        i_cookie -= i_upgradePrice;
        i_upgradePrice = i_upgradePrice + i_upgradePrice / 10;

        upgrade.Play();
    }
    public void AddMilkStockLimit()
    {
        if (!TestCookie())
            return;

        i_milkStockLimit += (i_cookieTotal / 100) + 10;
        i_cookie -= i_upgradePrice;
        i_upgradePrice = i_upgradePrice + i_upgradePrice / 10;

        upgrade.Play();
    }
    public void AddEggStockLimit()
    {
        if (!TestCookie())
            return;

        i_eggStockLimit += (i_cookieTotal / 100) + 10;
        i_cookie -= i_upgradePrice;
        i_upgradePrice = i_upgradePrice + i_upgradePrice / 10;

        upgrade.Play();
    }
    public void AddChocolateStockLimit()
    {
        if (!TestCookie())
            return;

        i_chocolateStockLimit += (i_cookieTotal / 100) + 10;
        i_cookie -= i_upgradePrice;
        i_upgradePrice = i_upgradePrice + i_upgradePrice / 10;

        upgrade.Play();
    }
    #endregion

    #region Take Ingredient
    //Function Take from stock
    public void TakeFlour()
    {
        i_flourPlayer += i_flourStock;
        i_flourStock = 0;
    }
    public void TakeMilk()
    {
        i_milkPlayer += i_milkStock;
        i_milkStock = 0;
    }
    public void TakeEgg()
    {
        i_eggPlayer += i_eggStock;
        i_eggStock = 0;
    }
    public void TakeChocolate()
    {
        i_chocolatePlayer += i_chocolateStock;
        i_chocolateStock = 0;
    }
    #endregion
}
