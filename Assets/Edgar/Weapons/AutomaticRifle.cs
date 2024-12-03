using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Edgar.Weapons {


    /// <summary>
    /// EJERCICIO
    /// 
    /// 
    /// Realizar la lógica detras de la recarga de el rifle
    /// 
    /// </summary>
    public class AutomaticRifle : Weapon
    {
        protected internal override void Shoot()
        {
            if (actualAmmo > 0)
            {
                base.Shoot();
                actualAmmo--;
                Debug.Log("taca taca taca taca");
            }
            if (actualAmmo == 0)
            {
                Reload();
                magazineSize--;
            }
        }

        protected internal override void Reload()
        {
            StartCoroutine(AutomaticRifleReload());
            Debug.Log("Recargo");
        }
        IEnumerator AutomaticRifleReload()
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