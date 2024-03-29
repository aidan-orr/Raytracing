﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Raytracing
{
	internal static class MathExt
	{
		public const float RadiansToDegress = 180 / MathF.PI;
		public const float DegreesToRadians = MathF.PI / 180;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Lerp(float start, float end, float amount) => (1 - amount) * start + amount * end;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector128<float> Lerp(Vector128<float> start, Vector128<float> end, float amount)
		{
			Vector128<float> amountVec = Vector128.Create(amount);
			Vector128<float> mAmountVec = Vector128.Create(1 - amount);
			Vector128<float> ev = Sse.Multiply(end, amountVec);
			Vector128<float> sv = Sse.Multiply(start, mAmountVec);
			return Sse.Add(sv, ev);
		}
	}
}
