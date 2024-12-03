using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// EJERCICIO
/// 
/// 
/// Realizar el funcionamiento para el disparo automatico de el rifle, pistola y escopeta.
/// El rifle debe de poder disparar automaticamente mientras se mantiene presionado el click izquierdo de el mouse
/// La escopeta y pistola deben de poder disparar 1 vez por click
/// 
/// </summary>
namespace Edgar.Weapons
{
    /// <summary>
    /// Este script nos maneja el uso de armas
    /// Controla el inventario de armas
    /// Selecciona cual es el arma que quieres equipar
    /// Y ajusta sus funciones/controles seg�n el arma equipada
    /// </summary>
    public class WeaponHandler : MonoBehaviour
    {

        [SerializeField] private Weapon[] weapons;
        [SerializeField] private Weapon currentWeapon;


        private void Update()
        {
            Aim();
            AutomaticAim();
        }

        public void Aim()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                currentWeapon.Shoot();
            }
        }
        public void AutomaticAim()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            { 
                if (currentWeapon is AutomaticRifle)
                {
                    currentWeapon.Shoot();
                }
            }
        }

    }
}