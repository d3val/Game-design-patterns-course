using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour {

    [SerializeField] int pointsPerLevel = 200;
    /*Este evento se configura en el inspector, es posible agregarle más comportamientos
     * al hacerlo publico y usar AddListener() en otras clases,
     * pero no estaría encapsulado y se podría abusar de el.*/
    [SerializeField] UnityEvent onLevelUp;
    int experiencePoints = 0;
    /*Action es un delegado propio de C#
     simplemente se le agrega el comportamiento requerido desde la clase que lo necesite*/
    public event Action OnLevelUpAction;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(.2f);
            GainExperience(10);
        }
    }

    public void GainExperience(int points)
    {
        int level = GetLevel();
        experiencePoints += points;

        if(GetLevel() > level)
        {
            onLevelUp.Invoke();

            //Si OnLevelUpAction no es null, que se invoque.
            OnLevelUpAction?.Invoke();
        }
    }

    public int GetExperience()
    {
        return experiencePoints;
    }

    public int GetLevel()
    {
        return experiencePoints / pointsPerLevel;
    }
}