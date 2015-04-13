// Copyright (C) 2015  James Liu
//	
//	This program is free software: you can redistribute it and/or modify
//	it under the terms of the GNU General Public License as published by
//	the Free Software Foundation, either version 3 of the License, or
//	(at your option) any later version.
//		
//	This program is distributed in the hope that it will be useful,
//	but WITHOUT ANY WARRANTY; without even the implied warranty of
//	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//	GNU General Public License for more details.
//			
//	You should have received a copy of the GNU General Public License
//	along with this program.  If not, see <http://www.gnu.org/licenses/>

using UnityEngine;
using UnityUtilLib;
using System.Collections;
using Danmaku2D.NoScript;

namespace Danmaku2D {

	[AddComponentMenu("Danmaku 2D/Danmaku Emitter")]
	public sealed class DanmakuEmitter : DanmakuTriggerReciever {

		[SerializeField]
		private DanmakuSource[] sources;

		[SerializeField]
		private FireBuilder fireData;

		[SerializeField]
		private IDanmakuController[] controllers;

		[SerializeField]
		private AudioClip fireSFX;

		[SerializeField]
		private float fireVolume = 1f;

//		public FireModifier Modifier {
//			get {
//				if(modifier == null)
//					return null;
//				return modifier.WrappedModifier;
//			}
//		}

		public void Fire() {
			fireData.Controller = null;
			for (int i = 0; i < controllers.Length; i++) {
				if(controllers[i] != null)
					fireData.Controller += controllers [i].UpdateDanmaku;
			}
			for(int i = 0; i < sources.Length; i++)
				sources[i].Fire (fireData);
			if (fireSFX != null)
				AudioManager.PlaySFX (fireSFX, fireVolume);
		}

		public void FireAtDanmaku(Danmaku danmaku) {
			FireBuilder copy = fireData.Clone ();
			copy.CoordinateSystem = DanmakuField.CoordinateSystem.World;
			copy.Position = danmaku.Position;
			copy.Rotation = danmaku.rotation;
			danmaku.Field.Fire(copy);
		}

		public void FireAtPoint(Vector2 position, DynamicFloat rotation, DanmakuField field) {
			FireBuilder copy = fireData.Clone ();
			copy.CoordinateSystem = DanmakuField.CoordinateSystem.World;
			copy.Position = position;
			copy.Rotation = rotation;
			field.Fire (copy);
		}

		#region implemented abstract members of DanmakuTriggerReciever

		public override void Trigger () {
			Fire ();
		}

		public override Color NodeColor {
			get {
				return Color.red;
			}
		}

		#endregion
	}
}