using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Task4 : MonoBehaviour {

    private void Start() {
        int[] numbers = { 3, -7, 12, -2, 9, -5, 8, -10, 15, -1 };

        Solution1(numbers);
        Solution2(numbers);


    }

    private void Solution1(int[] numbers) {
        print("Решение 1:");
        var answer = numbers.Where(x => x > 0).Reverse();
        print("Начальный массив: "+string.Join(", ", numbers));
        print("Результат: " + string.Join(", ", answer));
    }

    private void Solution2(int[] numbers) {
        print("Решение 2:");

        List<int> list = new List<int>();

        for (int i = numbers.Length - 1; i >= 0; i--) {
            if (numbers[i] > 0) {
                list.Add(numbers[i]);
            }
        }

        print("Начальный массив: " + string.Join(", ", numbers));
        print("Результат: " + string.Join(", ", list));
    }

}
