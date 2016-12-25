/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {

        public GameObject objChildAnimal;

        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }

            objChildAnimal = transform.GetChild(0).gameObject;
            if (!objChildAnimal)
            {
#if UNITY_EDITOR
                Debug.Log("thang nay khong co thang con!");
#endif
            }
            else
            {
                objChildAnimal.SetActive(false);
            }

        }
        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS

        #region PRIVATE_METHODS


        public void OnTrackingFound()
        {

            if (objChildAnimal && !objChildAnimal.activeInHierarchy)
            {
                objChildAnimal.SetActive(true);
            }
            Controller.Instance.m_listAnimalTracked.Add(objChildAnimal);
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        public void OnTrackingLost()
        {
            if (objChildAnimal && objChildAnimal.activeInHierarchy)
            {
                objChildAnimal.SetActive(false);
            }
            //GameController.Instance.currObjectTracked = null;

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

        #endregion // PRIVATE_METHODS
    }
}
