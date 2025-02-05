using System.Linq;
using UnityEngine;

public class Task3 : MonoBehaviour {

    private void Start() {
        int[] scores = { 45, 50, 38, 60, 55, 42, 47, 36, 29, 48, 51, 33, 40, 31, 37, 39, 44, 46, 32, 30 };

        Solution1(scores);
        Solution2(scores);
    }

    private void Solution1(int[] scores) {
        print("Решение 1:");

        int sumTop3 = scores.OrderByDescending(x => x).Take(3).Sum();

        print("Начальный массив: " + string.Join(", ", scores));
        print($"Результат: {sumTop3}");
    }

    private void Solution2(int[] scores) {
        print("Решение 2:");

        int[] maxScores = new int[3];

        foreach (int score in scores) {
            for (int index = 0; index < 3; index++) {
                if (score > maxScores[index]) {
                    maxScores[index] = score;
                    break;
                }
            }
        }

        int sum = 0;
        foreach (int score in maxScores) {
            sum += score;
        }

        print("Начальный массив: " + string.Join(", ", scores));
        print("Результат: " + sum);
    }
}
