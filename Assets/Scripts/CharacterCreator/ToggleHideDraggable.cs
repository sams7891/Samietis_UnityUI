using UnityEngine;
using UnityEngine.UI;

public class ToggleHideDraggable : MonoBehaviour
{
    [Header("Toggles")]
    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;

    [Header("Draggable Images by Group")]
    public GameObject[] group1Images; // 3 images
    public GameObject[] group2Images; // 3 images
    public GameObject[] group3Images; // 3 images

    [Header("Protected Target")]
    public RectTransform protectedTarget; // Images overlapping this will stay visible

    // Store original positions
    private Vector3[] group1StartPositions;
    private Vector3[] group2StartPositions;
    private Vector3[] group3StartPositions;

    private void Awake()
    {
        // Save initial positions of all images
        group1StartPositions = StoreStartPositions(group1Images);
        group2StartPositions = StoreStartPositions(group2Images);
        group3StartPositions = StoreStartPositions(group3Images);
    }

    private Vector3[] StoreStartPositions(GameObject[] group)
    {
        Vector3[] positions = new Vector3[group.Length];
        for (int i = 0; i < group.Length; i++)
        {
            positions[i] = group[i].transform.position;
        }
        return positions;
    }

    private void Start()
    {
        // Add listeners to toggles
        toggle1.onValueChanged.AddListener((isOn) => { if (isOn) ShowGroup(1); });
        toggle2.onValueChanged.AddListener((isOn) => { if (isOn) ShowGroup(2); });
        toggle3.onValueChanged.AddListener((isOn) => { if (isOn) ShowGroup(3); });

        // Initialize: show first group by default
        ShowGroup(1);
    }

    private void ShowGroup(int groupIndex)
    {
        ResetGroup(group1Images, group1StartPositions, groupIndex == 1);
        ResetGroup(group2Images, group2StartPositions, groupIndex == 2);
        ResetGroup(group3Images, group3StartPositions, groupIndex == 3);
    }

    private void ResetGroup(GameObject[] group, Vector3[] startPositions, bool showThisGroup)
    {
        for (int i = 0; i < group.Length; i++)
        {
            GameObject img = group[i];
            if (img == null) continue;

            RectTransform imgRect = img.GetComponent<RectTransform>();

            // If overlapping protected target, keep visible and don't reset position
            if (IsOverlapping(imgRect, protectedTarget))
            {
                img.SetActive(true);
                continue;
            }

            // Reset position and visibility
            img.transform.position = startPositions[i];
            img.SetActive(showThisGroup);
        }
    }

    private bool IsOverlapping(RectTransform a, RectTransform b)
    {
        if (a == null || b == null) return false;
        Rect rectA = GetWorldRect(a);
        Rect rectB = GetWorldRect(b);
        return rectA.Overlaps(rectB);
    }

    private Rect GetWorldRect(RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);
        Vector3 position = corners[0];
        Vector3 size = corners[2] - corners[0];
        return new Rect(position, size);
    }
}