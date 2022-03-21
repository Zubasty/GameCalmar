using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEye : MonoBehaviour
{
    [SerializeField] private GameObject _ray;
    [SerializeField] private float _timeLifeRay;

    [SerializeField] private GameObject _explosion;
    [SerializeField] private float _timeLifeExplosion;
    public void Attack(IPersonMove person)
    {
        Vector3 positionRay = (transform.position + person.gameObject.transform.position) / 2;
        GameObject ray = Instantiate(_ray);
        ray.transform.position = positionRay;
        ray.transform.localScale = new Vector3(ray.transform.localScale.x, Vector3.Distance(transform.position, person.gameObject.transform.position) / 2,
            ray.transform.localScale.z);
        float b = transform.position.y - person.gameObject.transform.position.y;
        ray.transform.rotation = Quaternion.Euler(0, 0, 90 + Mathf.Asin(b / ray.gameObject.transform.localScale.y) * 90 / Mathf.PI);
        person.GetDamage();
        GameObject explosion = Instantiate(_explosion, person.gameObject.transform.position, Quaternion.identity);
        Destroy(ray, _timeLifeRay);
        Destroy(explosion, _timeLifeExplosion);
    }
}
