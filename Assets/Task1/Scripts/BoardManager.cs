using UnityEngine;

public class BoardManager : MonoBehaviour {
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Checker checkerPrefab;
    [SerializeField] private Transform boardParent;
    [SerializeField] private Transform checkersParent;
    [SerializeField] private Color whiteCheckerColor;
    [SerializeField] private Color blackCheckerColor;

    private int boardSize = 8;
    private GameObject[,] boardCells;

    void Start() {
        GenerateBoard();
        PlaceCheckers();
    }

    void GenerateBoard() {
        boardCells = new GameObject[boardSize, boardSize];
        float offset = boardSize / 2 - 0.5f;
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();

        for (int x = 0; x < boardSize; x++) {
            for (int y = 0; y < boardSize; y++) {
                GameObject cell = Instantiate(cellPrefab, new Vector3(x - offset, 0, y - offset), Quaternion.identity, boardParent);

                Renderer rend = cell.GetComponent<Renderer>();
                propertyBlock.SetColor("_Color", (x + y) % 2 == 0 ? Color.white : Color.black);
                rend.SetPropertyBlock(propertyBlock);

                boardCells[x, y] = cell;
            }
        }
    }

    void PlaceCheckers() {
        float offset = boardSize / 2 - 0.5f;
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();

        for (int x = 0; x < boardSize; x++) {
            for (int y = 0; y < boardSize; y++) {
                if ((x + y) % 2 != 0 && (y < 3 || y > 4)) {
                    Checker checker = Instantiate(checkerPrefab, new Vector3(x - offset, 0.35f, y - offset), Quaternion.identity, checkersParent);
                    Renderer rend = checker.GetComponent<Renderer>();
                    if (y < 3) {
                        propertyBlock.SetColor("_Color", whiteCheckerColor);
                    }
                    else {
                        propertyBlock.SetColor("_Color", blackCheckerColor);
                    }
                    rend.SetPropertyBlock(propertyBlock);
                }
            }
        }
    }
}
