using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Edgar.Weapons
{
    /// <summary>
    /// EJERCICIO
    /// 
    /// 
    /// Realizar la lógica detras de la recarga de la pistola como si esta fuera un revolver
    /// 
    /// </summary>
    public class Handgun : Weapon
    {
        protected internal override void Shoot()
        {
            if (actualAmmo > 0)
            {
                base.Shoot();
                actualAmmo--;
                Debug.Log("piu piu");
            }
            if (actualAmmo == 0)
            {
                Reload();
                magazineSize--;
            }
            if (magazineSize == 0)
            {
                actualAmmo = -1;
                magazineSize = 0;
                Debug.Log("Se acabaron las reservas");
            }
        }

        protected internal override void Reload()
        {
            StartCoroutine(HanddGunReload());
            Debug.Log("Recargo");
        }
        IEnumerator HanddGunReload()
        {
            float reloadTimeElapsed = 0f;

            while (reloadTimeElapsed < reloadTime)
            {
                reloadTimeElapsed += Time.deltaTime;
                actualAmmo = Mathf.FloorToInt(Mathf.Lerp(0, maxAmmo, reloadTimeElapsed / reloadTime));
                yield return null;
                actualAmmo = maxAmmo;
            }
        }

    }


}

