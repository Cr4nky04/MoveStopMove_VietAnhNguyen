using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameList  
{
    public static int nameCount = 150;

    private static List<string> m_ExistedName = new List<string>();

    public static string AddRandomName()
    {
        int indexName;
        do
        {
            indexName = Random.Range(0, nameCount);

        }
        while (m_ExistedName.Contains(ListOfName[indexName]));
        m_ExistedName.Add(ListOfName[indexName]);
        return ListOfName[indexName];
    }

    public static List<string> ListOfName = new List<string>
    {
        "Chasity Farley"  ,
        "Reese Thomas"    ,
        "Alicia Rice" ,
        "Jasper Ponce"    ,
        "Marely Avila"    ,
        "Deacon Waters"   ,
        "Jennifer Hampton"    ,
        "Hassan Vang" ,
        "Dexter Stanton"  ,
        "Mira Leonard"    ,
        "Winston Carpenter"   ,
        "Hadassah Macdonald"  ,
        "Leticia Morton"  ,
        "Javion Cameron"  ,
        "Ariel Duncan"    ,
        "Jenna Hoover"    ,
        "Kareem Campos"   ,
        "Elizabeth Mclaughlin"    ,
        "Dylan Fisher"    ,
        "Denise Mueller"  ,
        "Joy Reeves"  ,
        "Emilie Long" ,
        "Ernesto Bradley" ,
        "Javion Owen" ,
        "Lane Terrell"    ,
        "Ashtyn Russell"  ,
        "Quinn Stanton"   ,
        "Brady Houston"   ,
        "Jax Blair"   ,
        "Noelle Vang" ,
        "Jordin Faulkner" ,
        "Terrance Moss"   ,
        "Phoebe Contreras"    ,
        "Elisa Marsh" ,
        "Lilianna Wagner" ,
        "Laylah Arroyo"   ,
        "Arthur Melendez" ,
        "Khloe Noble" ,
        "Devan Anderson"  ,
        "Deandre Robertson"   ,
        "Gabriel Lutz"    ,
        "Precious Good"   ,
        "Nevaeh Gillespie"    ,
        "Cory Everett"    ,
        "Siena Schneider" ,
        "Quincy Dorsey"   ,
        "Angel Guerra"    ,
        "Bryce Santana"   ,
        "Evelin Whitehead"    ,
        "Laci Winters"    ,
        "Mira Cantrell"   ,
        "Zachary Crosby"  ,
        "Averie Santiago" ,
        "Talan Stewart"   ,
        "Miah Vang"   ,
        "Julissa Robinson"    ,
        "Kash Brennan"    ,
        "Skye Galvan" ,
        "Vicente Cross"   ,
        "Coby Russo"  ,
        "Yoselin Chen"    ,
        "Stephanie Cortez"    ,
        "Alyvia Fry"  ,
        "Sherlyn Cooper"  ,
        "Mikayla Rivers"  ,
        "Donald Duffy"    ,
        "Allyson Lewis"   ,
        "Leia Stevens"    ,
        "Sylvia Jacobson" ,
        "Maren Pratt" ,
        "Eileen Duke" ,
        "Maximillian Petersen"    ,
        "Benjamin Payne"  ,
        "Riley Rivers"    ,
        "Jaron Mercer"    ,
        "Nathanael Phillips"  ,
        "Maia Silva"  ,
        "Jaxson Willis"   ,
        "Rosemary Barajas"    ,
        "Keaton Simmons"  ,
        "Giovanni Barr"   ,
        "Mckinley Greene" ,
        "Ivan Pineda" ,
        "Mateo Sellers"   ,
        "Zaiden Nguyen"   ,
        "Adalynn Underwood"   ,
        "Duncan Moss" ,
        "Tamia Jackson"   ,
        "Dayanara Alvarado"   ,
        "Brynn Cook"  ,
        "Tristian Ashley" ,
        "Daisy Levy"  ,
        "Dana Mcdowell"   ,
        "Caroline Guzman" ,
        "Selah Flores"    ,
        "Bronson Curry"   ,
        "Isla Barton" ,
        "Jazmyn Zimmerman"    ,
        "Angelica Robertson"  ,
        "Milo Horne"  ,
        "April Perry" ,
        "Harper Orozco"   ,
        "Magdalena Nguyen"    ,
        "Alison Soto" ,
        "Sophie Durham"   ,
        "Damian Chandler" ,
        "Carlie Huff" ,
        "Haylie Sutton"   ,
        "Lorena Mcconnell"    ,
        "Rosa Parrish"    ,
        "Edgar Schmidt"   ,
        "Jaslene Smith"   ,
        "Abraham Barr"    ,
        "Claudia Carter"  ,
        "Milton Fitzpatrick"  ,
        "Brenden Cunningham"  ,
        "Johnathan Roy"   ,
        "Jairo Blake" ,
        "Damon Hendrix"   ,
        "Jaylynn Clarke"  ,
        "Gracie Wilcox"   ,
        "Londyn Calhoun"  ,
        "Lawrence Freeman"    ,
        "Greta Barker"    ,
        "Tomas Berger"    ,
        "Solomon Bass"    ,
        "Jay Fletcher"    ,
        "Dante Myers" ,
        "Leah Blackburn"  ,
        "Brett Owens" ,
        "Zachery Mcmillan"    ,
        "Chad Strong" ,
        "Collin Andrews"  ,
        "Dayton Cobb" ,
        "Elijah Floyd"    ,
        "Kamron Graves"   ,
        "Justice Hodges"  ,
        "Cale Ingram" ,
        "Dante Cuevas"    ,
        "Kendra Farmer"   ,
        "Adrienne Gilmore"    ,
        "Audrey Bond" ,
        "Yesenia Lucas"   ,
        "Abagail Maynard" ,
        "Javion Clark"    ,
        "Kyleigh Brown"   ,
        "Caroline Chandler"   ,
        "Keon Silva"  ,
        "Finley Rubio"    ,
        "Wayne Mcclure"   ,

    };
}
