using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator CharacterLoop()
    {

        yield return null;
    }

    IEnumerator RunLoop()
    {
        yield return null;
    }



    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 distance = targetPosition - transform.position;
        transform.rotation = Quaternion.LookRotation(distance);
    }

    bool RunTowards(Vector3 targetPosition, float radius)
    {
        //Vector3 distance = targetPosition - transform.position;
        //Vector3 direction = distance.normalized;
        //transform.rotation = Quaternion.LookRotation(direction);

        //Vector3 vector = direction * runSpeed;

        //if (vector.magnitude < distance.magnitude - radius)
        //{
        //    transform.position += vector;
        //    return false;
        //}

        //transform.position = targetPosition - direction * radius;
        return true;
    }
}
