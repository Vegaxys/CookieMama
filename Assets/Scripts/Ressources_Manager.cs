using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressources_Manager : MonoBehaviour
{
    public int i_cookie;
    public int i_cookiePerSecond;
    public float f_cookieCadence;
    private float f_cookieCadenceInitial;

    //Valeurs Ressources
    public int i_flour;
    public int i_milk;
    public int i_egg;
    public int i_chocolate;

    //Addition Ressources
    /*public float f_addChocolat;
    public float f_addFarine;
    public float f_addLait;
    public float f_addOeuf;

    public float f_ressourcesCadence;
    private float f_ressourcesCadenceInitial;*/

    void Start()
    {
        f_cookieCadenceInitial = f_cookieCadence;
        //f_ressourcesCadenceInitial = f_ressourcesCadence;
    }

    void Update()
    {
        f_cookieCadence -= Time.deltaTime;
        //f_ressourcesCadence -= Time.deltaTime;

        //Recette Cookie
        if(i_chocolate >= 1 && i_flour >= 2 && i_milk >= 3 && i_egg >= 4)
        {
            if (f_cookieCadence <= 0)
            {
                //f_cookie += 1;
                i_cookie += CreateCookie(1, 2, 3, 4);
                f_cookieCadence = f_cookieCadenceInitial;
            }

            /*if (f_ressourcesCadence <= 0)
            {
                i_flour -= 1;
                i_milk -= 1;
                i_egg -= 1;
                i_chocolate -= 1;
                f_ressourcesCadence = f_ressourcesCadenceInitial;
            }*/
        }

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

        if (Input.GetKeyDown(KeyCode.Y))
        {
            AddCookiePerSecond(1);
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

    void AddFlour(int addFlour)
    {
        //f_farine += f_addFarine;
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
        //f_chocolat += f_addChocolat;
        i_chocolate += addChocolate;
    }

    void AddCookiePerSecond(int addCookiePerSecond)
    {
        //f_chocolat += f_addChocolat;
        i_cookiePerSecond += addCookiePerSecond;
    }
}
