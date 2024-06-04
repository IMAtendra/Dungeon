using UnityEngine;

public class TiltRotator : MonoBehaviour
{
        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        private void Start()
        {

                LeanTween.rotate(gameObject, transform.position, 1f);
                // Moves Up and Down
                // iTween.MoveBy(
                //         target: gameObject,
                //         args: iTween.Hash("y",
                //                           1,
                //                           "easeType",
                //                           "linear",
                //                           "loopType",
                //                           "pingPong",
                //                           "delay",
                //                           .1));


                // Rotate Left & Right
                // iTween.RotateBy(
                //         target: gameObject,
                //         args: iTween.Hash("y",
                //                           1,
                //                           "easeType",
                //                           "linear",
                //                           "loopType",
                //                           "loop",
                //                           "delay",
                //                           0));
        }
}