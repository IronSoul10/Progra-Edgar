using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Angie.Weapons
{
    /// <summary>
    /// EJERCICIO
    /// 
    /// 
    /// Realizar la lógica detras de la recarga de la escopeta suponiendo que fuera una de doble barril
    /// 
    /// Realizar el disparo de la escopeta por perdigones.
    /// 
    /// </summary>
    public class Shotgun : Weapon
    {

        protected internal override void Shoot()
        {
           
            // escribir la dispersion

        }

        protected internal override void Reload()
        {
            Debug.Log("Recargo");
        }
    }
}