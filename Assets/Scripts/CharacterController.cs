using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.InputSystem.InputAction;
public class CharacterController : MonoBehaviour
{
    private Vector2 movementInput;
    [SerializeField] private float movementSpeed;
    private bool PlayerPaused;
    private Vector3 currentPosition;
    private Vector3 lastPosition;
    private Tilemap m_Tilemap;
    public Tilemap Tilemap
    {
        get { if (m_Tilemap == null) m_Tilemap = FindAnyObjectByType<Tilemap>(); return m_Tilemap; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPaused = false;
    }
    public void Movement(CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerPaused) return;
        transform.Translate(movementSpeed * Time.deltaTime * new Vector2(movementInput.x, movementInput.y));
        currentPosition = Tilemap.WorldToCell(transform.position);
    }
}
