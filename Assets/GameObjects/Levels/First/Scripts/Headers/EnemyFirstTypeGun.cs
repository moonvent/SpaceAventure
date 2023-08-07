using System.Collections;
using UnityEngine;


/// <summary>
/// Пушка для врага
/// </summary>
public class EnemyFirstTypeGun : Gun
{
    /// <summary>
    /// Длина - кол-во снарядов
    /// </summary>
    int[] shotsAmount = { 1, 1, 1 };

    private void OneShot()
    {
        CreateBulletInstance();
        bullet.GetComponent<Bullet>().BulletParamsInit();
    }

    public IEnumerator EnemyShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            foreach (int item in shotsAmount)
            {
                OneShot();
                yield return new WaitForSeconds(0.3f);
            }
        }
    }
}
