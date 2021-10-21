﻿//-----------------------------------------------------------------------
// <copyright file="DragGestureRecognizer.cs" company="Google">
//
// Copyright 2018 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

// Modifications copyright © 2020 Unity Technologies ApS

#if AR_FOUNDATION_PRESENT || PACKAGE_DOCS_GENERATION

using UnityEngine;

namespace UnityEngine.XR.Interaction.Toolkit.AR
{
    /// <summary>
    /// Gesture Recognizer for when the user performs a drag motion on the touch screen.
    /// </summary>
    /// <inheritdoc />
    public class DragGestureRecognizer : GestureRecognizer<DragGesture>
    {
        /// <summary>
        /// Distance in inches a user's touch can drift from the start position
        /// before the drag gesture is interpreted as started.
        /// </summary>
        public float slopInches { get; set; } = 0.1f;

        /// <summary>
        /// Creates a Drag gesture with the given touch.
        /// </summary>
        /// <param name="touch">The touch that started this gesture.</param>
        /// <returns>Returns the created Drag gesture.</returns>
        internal DragGesture CreateGesture(Touch touch)
        {
            return new DragGesture(this, touch);
        }

        /// <summary>
        /// Creates a Drag gesture with the given touch.
        /// </summary>
        /// <param name="touch">The touch that started this gesture.</param>
        /// <returns>Returns the created Drag gesture.</returns>
        internal DragGesture CreateEnhancedGesture(InputSystem.EnhancedTouch.Touch touch)
        {
            return new DragGesture(this, touch);
        }

        /// <inheritdoc />
        protected override void TryCreateGestures()
        {
            if (GestureTouchesUtility.touchInputSource == GestureTouchesUtility.TouchInputSource.Enhanced)
                TryCreateOneFingerGestureOnTouchBegan(CreateEnhancedGesture);
            else
                TryCreateOneFingerGestureOnTouchBegan(CreateGesture);
        }
    }
}

#endif
