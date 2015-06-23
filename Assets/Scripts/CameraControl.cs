using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public float screenMovePercentage = 0.1f;
    public float moveSpeed = 1f;
    public Camera camera;

    public Vector2 maxConstraints;
    public Vector2 minConstraints;

    public bool enableDragRotate, enableDragMove, enableCursorMove, enableFocusZoom;

    Transform mTrans;
    Vector3 mMouse;
    Vector3 mTargetPos;
    Vector3 mTargetEuler;

    Quaternion normalCameraRot;
    Quaternion focusCameraRot = Quaternion.Euler(90, 0, 0);

    bool focusZoom = false;

    float leftPixels, upPixels, rightPixels, downPixels;

    void Start() {
        mTrans = transform;
        mMouse = Input.mousePosition;
        mTargetPos = mTrans.position;
        mTargetEuler = mTrans.rotation.eulerAngles;

        leftPixels = Screen.width * screenMovePercentage;
        rightPixels = Screen.width * (1.0f - screenMovePercentage);
        upPixels = Screen.height * screenMovePercentage;
        downPixels = Screen.height * (1.0f - screenMovePercentage);

        normalCameraRot = camera.transform.rotation;
    }

    void Update() {
        Vector3 delta = Input.mousePosition - mMouse;
        mMouse = Input.mousePosition;

        if (enableDragRotate && Input.GetButton("Fire1")) {
            mTargetEuler.y += Time.deltaTime * 10f * delta.x;
        }

        if (enableDragMove && Input.GetButton("Fire2")) {
            Vector3 dir = transform.rotation * Vector3.forward;
            dir.y = 0f;
            dir.Normalize();
            Quaternion rot = Quaternion.LookRotation(dir);
            mTargetPos += rot * new Vector3(delta.x * 0.1f, 0f, delta.y * 0.1f);
        }

        if (enableCursorMove && (mMouse.x < leftPixels || mMouse.x > rightPixels || mMouse.y < upPixels || mMouse.y > downPixels)) {
            Vector3 dir = transform.rotation * Vector3.forward;
            dir.y = 0f;
            dir.Normalize();
            Quaternion rot = Quaternion.LookRotation(dir);
            Vector3 distance = new Vector3(0,0,0);

            if (mMouse.x < leftPixels || mMouse.x > rightPixels)
                distance.x = mMouse.x < leftPixels ? -moveSpeed : moveSpeed;

            if (mMouse.y < upPixels || mMouse.y > downPixels)
                distance.z = mMouse.y < upPixels ? -moveSpeed : moveSpeed;

            mTargetPos += rot * distance;
        }

        if (enableFocusZoom && Input.GetButtonDown("Focus")) {
            if (!focusZoom) {
                camera.transform.rotation = focusCameraRot;
                camera.orthographic = true;
            } else {
                camera.transform.rotation = normalCameraRot;
                camera.orthographic = false;
            }

            focusZoom = !focusZoom;
        }

        mTargetPos.x = Mathf.Clamp(mTargetPos.x, minConstraints.x, maxConstraints.x);
        mTargetPos.z = Mathf.Clamp(mTargetPos.z, minConstraints.y, maxConstraints.y);

        float deltaTime = Time.deltaTime * 8f;
        mTrans.position = Vector3.Lerp(mTrans.position, mTargetPos, deltaTime);
        mTrans.rotation = Quaternion.Slerp(mTrans.rotation, Quaternion.Euler(mTargetEuler), deltaTime);
    }
}
