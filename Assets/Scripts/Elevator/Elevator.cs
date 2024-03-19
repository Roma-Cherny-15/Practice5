using System.Collections;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("InElevator");
            // ��������� �������� ��� ���������� ����
            StartCoroutine(MoveElevator());
        }
    }

    private IEnumerator MoveElevator()
    {
        yield return new WaitForSeconds(2);
        // ��������� �������� ����������
        float speed = 2.0f;

        // �������� ��������� ������� ����
        Vector3 startPosition = transform.position;

        // �������� ������� ������� ����
        Vector3 targetPosition = new Vector3(startPosition.x, startPosition.y + 10.0f, startPosition.z);

        // ��������� ��� �� ������� �������
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}