using UnityEngine;
using UnityEngine.UI;

public class DraggableVisibilityManager : MonoBehaviour
{
    [Header("Draggable Images by Group")]
    public GameObject[] group1Images;
    public GameObject[] group2Images;
    public GameObject[] group3Images;

    [Header("Protected Target")]
    public RectTransform protectedTarget; // Images overlapping this will stay visible

    // Store original positions
    private Vector3[] group1StartPositions;
    private Vector3[] group2StartPositions;
    private Vector3[] group3StartPositions;

    private void Awake()
    {
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

    /// <summary>
    /// Show only the selected group, reset positions, but keep images overlapping the protected target visible
    /// </summary>
    public void ShowGroup(int groupIndex)
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

            // If image is overlapping the protected target, do not hide or move it
            if (IsOverlapping(imgRect, protectedTarget))
            {
                img.SetActive(true);
                continue;
            }

            // Reset position and set visibility based on the group
            img.transform.position = startPositions[i];
            img.SetActive(showThisGroup);
        }
    }

    /// <summary>
    /// Checks if two RectTransforms overlap in screen space
    /// </summary>
    private bool IsOverlapping(RectTransform a, RectTransform b)
    {
        if (a == null || b == null) return false;

        Rect rectA = GetWorldRect(a);
        Rect rectB = GetWorldRect(b);
        return rectA.Overlaps(rectB);
    }

    /// <summary>
    /// Converts a RectTransform to a world-space Rect
    /// </summary>
    private Rect GetWorldRect(RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);
        Vector3 position = corners[0];
        Vector3 size = corners[2] - corners[0];
        return new Rect(position, size);
    }
}