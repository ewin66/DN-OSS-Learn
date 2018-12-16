// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/******************************************************************************
 * This file is auto-generated from a template file by the GenerateTests.csx  *
 * script in tests\src\JIT\HardwareIntrinsics\X86\Shared. In order to make    *
 * changes, please update the corresponding template and run according to the *
 * directions listed in the file.                                             *
 ******************************************************************************/

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace JIT.HardwareIntrinsics.X86
{
    public static partial class Program
    {
        private static void BlendVariableSingle()
        {
            var test = new SimpleTernaryOpTest__BlendVariableSingle();

            if (test.IsSupported)
            {
                // Validates basic functionality works, using Unsafe.Read
                test.RunBasicScenario_UnsafeRead();

                if (Sse.IsSupported)
                {
                    // Validates basic functionality works, using Load
                    test.RunBasicScenario_Load();

                    // Validates basic functionality works, using LoadAligned
                    test.RunBasicScenario_LoadAligned();
                }

                // Validates calling via reflection works, using Unsafe.Read
                test.RunReflectionScenario_UnsafeRead();

                if (Sse.IsSupported)
                {
                    // Validates calling via reflection works, using Load
                    test.RunReflectionScenario_Load();

                    // Validates calling via reflection works, using LoadAligned
                    test.RunReflectionScenario_LoadAligned();
                }

                // Validates passing a static member works
                test.RunClsVarScenario();

                // Validates passing a local works, using Unsafe.Read
                test.RunLclVarScenario_UnsafeRead();

                if (Sse.IsSupported)
                {
                    // Validates passing a local works, using Load
                    test.RunLclVarScenario_Load();

                    // Validates passing a local works, using LoadAligned
                    test.RunLclVarScenario_LoadAligned();
                }

                // Validates passing the field of a local class works
                test.RunClassLclFldScenario();

                // Validates passing an instance member of a class works
                test.RunClassFldScenario();

                // Validates passing the field of a local struct works
                test.RunStructLclFldScenario();

                // Validates passing an instance member of a struct works
                test.RunStructFldScenario();
            }
            else
            {
                // Validates we throw on unsupported hardware
                test.RunUnsupportedScenario();
            }

            if (!test.Succeeded)
            {
                throw new Exception("One or more scenarios did not complete as expected.");
            }
        }
    }

    public sealed unsafe class SimpleTernaryOpTest__BlendVariableSingle
    {
        private struct TestStruct
        {
            public Vector128<Single> _fld1;
            public Vector128<Single> _fld2;
            public Vector128<Single> _fld3;

            public static TestStruct Create()
            {
                var testStruct = new TestStruct();

                for (var i = 0; i < Op1ElementCount; i++) { _data1[i] = TestLibrary.Generator.GetSingle(); }
                Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector128<Single>, byte>(ref testStruct._fld1), ref Unsafe.As<Single, byte>(ref _data1[0]), (uint)Unsafe.SizeOf<Vector128<Single>>());
                for (var i = 0; i < Op2ElementCount; i++) { _data2[i] = TestLibrary.Generator.GetSingle(); }
                Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector128<Single>, byte>(ref testStruct._fld2), ref Unsafe.As<Single, byte>(ref _data2[0]), (uint)Unsafe.SizeOf<Vector128<Single>>());
                for (var i = 0; i < Op3ElementCount; i++) { _data3[i] = (float)(((i % 2) == 0) ? -0.0 : 1.0); }
                Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector128<Single>, byte>(ref _clsVar3), ref Unsafe.As<Single, byte>(ref _data3[0]), (uint)Unsafe.SizeOf<Vector128<Single>>());

                return testStruct;
            }

            public void RunStructFldScenario(SimpleTernaryOpTest__BlendVariableSingle testClass)
            {
                var result = Sse41.BlendVariable(_fld1, _fld2, _fld3);

                Unsafe.Write(testClass._dataTable.outArrayPtr, result);
                testClass.ValidateResult(_fld1, _fld2, _fld3, testClass._dataTable.outArrayPtr);
            }
        }

        private static readonly int LargestVectorSize = 16;

        private static readonly int Op1ElementCount = Unsafe.SizeOf<Vector128<Single>>() / sizeof(Single);
        private static readonly int Op2ElementCount = Unsafe.SizeOf<Vector128<Single>>() / sizeof(Single);
        private static readonly int Op3ElementCount = Unsafe.SizeOf<Vector128<Single>>() / sizeof(Single);
        private static readonly int RetElementCount = Unsafe.SizeOf<Vector128<Single>>() / sizeof(Single);

        private static Single[] _data1 = new Single[Op1ElementCount];
        private static Single[] _data2 = new Single[Op2ElementCount];
        private static Single[] _data3 = new Single[Op3ElementCount];

        private static Vector128<Single> _clsVar1;
        private static Vector128<Single> _clsVar2;
        private static Vector128<Single> _clsVar3;

        private Vector128<Single> _fld1;
        private Vector128<Single> _fld2;
        private Vector128<Single> _fld3;

        private SimpleTernaryOpTest__DataTable<Single, Single, Single, Single> _dataTable;

        static SimpleTernaryOpTest__BlendVariableSingle()
        {
            for (var i = 0; i < Op1ElementCount; i++) { _data1[i] = TestLibrary.Generator.GetSingle(); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector128<Single>, byte>(ref _clsVar1), ref Unsafe.As<Single, byte>(ref _data1[0]), (uint)Unsafe.SizeOf<Vector128<Single>>());
            for (var i = 0; i < Op2ElementCount; i++) { _data2[i] = TestLibrary.Generator.GetSingle(); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector128<Single>, byte>(ref _clsVar2), ref Unsafe.As<Single, byte>(ref _data2[0]), (uint)Unsafe.SizeOf<Vector128<Single>>());
            for (var i = 0; i < Op3ElementCount; i++) { _data3[i] = (float)(((i % 2) == 0) ? -0.0 : 1.0); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector128<Single>, byte>(ref _clsVar3), ref Unsafe.As<Single, byte>(ref _data3[0]), (uint)Unsafe.SizeOf<Vector128<Single>>());
        }

        public SimpleTernaryOpTest__BlendVariableSingle()
        {
            Succeeded = true;

            for (var i = 0; i < Op1ElementCount; i++) { _data1[i] = TestLibrary.Generator.GetSingle(); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector128<Single>, byte>(ref _fld1), ref Unsafe.As<Single, byte>(ref _data1[0]), (uint)Unsafe.SizeOf<Vector128<Single>>());
            for (var i = 0; i < Op2ElementCount; i++) { _data2[i] = TestLibrary.Generator.GetSingle(); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector128<Single>, byte>(ref _fld2), ref Unsafe.As<Single, byte>(ref _data2[0]), (uint)Unsafe.SizeOf<Vector128<Single>>());
            for (var i = 0; i < Op3ElementCount; i++) { _data3[i] = (float)(((i % 2) == 0) ? -0.0 : 1.0); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector128<Single>, byte>(ref _fld3), ref Unsafe.As<Single, byte>(ref _data3[0]), (uint)Unsafe.SizeOf<Vector128<Single>>());

            for (var i = 0; i < Op1ElementCount; i++) { _data1[i] = TestLibrary.Generator.GetSingle(); }
            for (var i = 0; i < Op2ElementCount; i++) { _data2[i] = TestLibrary.Generator.GetSingle(); }
            for (var i = 0; i < Op3ElementCount; i++) { _data3[i] = (float)(((i % 2) == 0) ? -0.0 : 1.0); }
            _dataTable = new SimpleTernaryOpTest__DataTable<Single, Single, Single, Single>(_data1, _data2, _data3, new Single[RetElementCount], LargestVectorSize);
        }

        public bool IsSupported => Sse41.IsSupported;

        public bool Succeeded { get; set; }

        public void RunBasicScenario_UnsafeRead()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunBasicScenario_UnsafeRead));

            var result = Sse41.BlendVariable(
                Unsafe.Read<Vector128<Single>>(_dataTable.inArray1Ptr),
                Unsafe.Read<Vector128<Single>>(_dataTable.inArray2Ptr),
                Unsafe.Read<Vector128<Single>>(_dataTable.inArray3Ptr)
            );

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, _dataTable.inArray3Ptr, _dataTable.outArrayPtr);
        }

        public void RunBasicScenario_Load()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunBasicScenario_Load));

            var result = Sse41.BlendVariable(
                Sse.LoadVector128((Single*)(_dataTable.inArray1Ptr)),
                Sse.LoadVector128((Single*)(_dataTable.inArray2Ptr)),
                Sse.LoadVector128((Single*)(_dataTable.inArray3Ptr))
            );

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, _dataTable.inArray3Ptr, _dataTable.outArrayPtr);
        }

        public void RunBasicScenario_LoadAligned()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunBasicScenario_LoadAligned));

            var result = Sse41.BlendVariable(
                Sse.LoadAlignedVector128((Single*)(_dataTable.inArray1Ptr)),
                Sse.LoadAlignedVector128((Single*)(_dataTable.inArray2Ptr)),
                Sse.LoadAlignedVector128((Single*)(_dataTable.inArray3Ptr))
            );

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, _dataTable.inArray3Ptr, _dataTable.outArrayPtr);
        }

        public void RunReflectionScenario_UnsafeRead()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunReflectionScenario_UnsafeRead));

            var result = typeof(Sse41).GetMethod(nameof(Sse41.BlendVariable), new Type[] { typeof(Vector128<Single>), typeof(Vector128<Single>), typeof(Vector128<Single>) })
                                     .Invoke(null, new object[] {
                                        Unsafe.Read<Vector128<Single>>(_dataTable.inArray1Ptr),
                                        Unsafe.Read<Vector128<Single>>(_dataTable.inArray2Ptr),
                                        Unsafe.Read<Vector128<Single>>(_dataTable.inArray3Ptr)
                                     });

            Unsafe.Write(_dataTable.outArrayPtr, (Vector128<Single>)(result));
            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, _dataTable.inArray3Ptr, _dataTable.outArrayPtr);
        }

        public void RunReflectionScenario_Load()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunReflectionScenario_Load));

            var result = typeof(Sse41).GetMethod(nameof(Sse41.BlendVariable), new Type[] { typeof(Vector128<Single>), typeof(Vector128<Single>), typeof(Vector128<Single>) })
                                     .Invoke(null, new object[] {
                                        Sse.LoadVector128((Single*)(_dataTable.inArray1Ptr)),
                                        Sse.LoadVector128((Single*)(_dataTable.inArray2Ptr)),
                                        Sse.LoadVector128((Single*)(_dataTable.inArray3Ptr))
                                     });

            Unsafe.Write(_dataTable.outArrayPtr, (Vector128<Single>)(result));
            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, _dataTable.inArray3Ptr, _dataTable.outArrayPtr);
        }

        public void RunReflectionScenario_LoadAligned()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunReflectionScenario_LoadAligned));

            var result = typeof(Sse41).GetMethod(nameof(Sse41.BlendVariable), new Type[] { typeof(Vector128<Single>), typeof(Vector128<Single>), typeof(Vector128<Single>) })
                                     .Invoke(null, new object[] {
                                        Sse.LoadAlignedVector128((Single*)(_dataTable.inArray1Ptr)),
                                        Sse.LoadAlignedVector128((Single*)(_dataTable.inArray2Ptr)),
                                        Sse.LoadAlignedVector128((Single*)(_dataTable.inArray3Ptr))
                                     });

            Unsafe.Write(_dataTable.outArrayPtr, (Vector128<Single>)(result));
            ValidateResult(_dataTable.inArray1Ptr, _dataTable.inArray2Ptr, _dataTable.inArray3Ptr, _dataTable.outArrayPtr);
        }

        public void RunClsVarScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunClsVarScenario));

            var result = Sse41.BlendVariable(
                _clsVar1,
                _clsVar2,
                _clsVar3
            );

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(_clsVar1, _clsVar2, _clsVar3, _dataTable.outArrayPtr);
        }

        public void RunLclVarScenario_UnsafeRead()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunLclVarScenario_UnsafeRead));

            var firstOp = Unsafe.Read<Vector128<Single>>(_dataTable.inArray1Ptr);
            var secondOp = Unsafe.Read<Vector128<Single>>(_dataTable.inArray2Ptr);
            var thirdOp = Unsafe.Read<Vector128<Single>>(_dataTable.inArray3Ptr);
            var result = Sse41.BlendVariable(firstOp, secondOp, thirdOp);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(firstOp, secondOp, thirdOp, _dataTable.outArrayPtr);
        }

        public void RunLclVarScenario_Load()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunLclVarScenario_Load));

            var firstOp = Sse.LoadVector128((Single*)(_dataTable.inArray1Ptr));
            var secondOp = Sse.LoadVector128((Single*)(_dataTable.inArray2Ptr));
            var thirdOp = Sse.LoadVector128((Single*)(_dataTable.inArray3Ptr));
            var result = Sse41.BlendVariable(firstOp, secondOp, thirdOp);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(firstOp, secondOp, thirdOp, _dataTable.outArrayPtr);
        }

        public void RunLclVarScenario_LoadAligned()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunLclVarScenario_LoadAligned));

            var firstOp = Sse.LoadAlignedVector128((Single*)(_dataTable.inArray1Ptr));
            var secondOp = Sse.LoadAlignedVector128((Single*)(_dataTable.inArray2Ptr));
            var thirdOp = Sse.LoadAlignedVector128((Single*)(_dataTable.inArray3Ptr));
            var result = Sse41.BlendVariable(firstOp, secondOp, thirdOp);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(firstOp, secondOp, thirdOp, _dataTable.outArrayPtr);
        }

        public void RunClassLclFldScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunClassLclFldScenario));

            var test = new SimpleTernaryOpTest__BlendVariableSingle();
            var result = Sse41.BlendVariable(test._fld1, test._fld2, test._fld3);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(test._fld1, test._fld2, test._fld3, _dataTable.outArrayPtr);
        }

        public void RunClassFldScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunClassFldScenario));

            var result = Sse41.BlendVariable(_fld1, _fld2, _fld3);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(_fld1, _fld2, _fld3, _dataTable.outArrayPtr);
        }

        public void RunStructLclFldScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunStructLclFldScenario));

            var test = TestStruct.Create();
            var result = Sse41.BlendVariable(test._fld1, test._fld2, test._fld3);

            Unsafe.Write(_dataTable.outArrayPtr, result);
            ValidateResult(test._fld1, test._fld2, test._fld3, _dataTable.outArrayPtr);
        }

        public void RunStructFldScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunStructFldScenario));

            var test = TestStruct.Create();
            test.RunStructFldScenario(this);
        }

        public void RunUnsupportedScenario()
        {
            TestLibrary.TestFramework.BeginScenario(nameof(RunUnsupportedScenario));

            bool succeeded = false;

            try
            {
                RunBasicScenario_UnsafeRead();
            }
            catch (PlatformNotSupportedException)
            {
                succeeded = true;
            }

            if (!succeeded)
            {
                Succeeded = false;
            }
        }

        private void ValidateResult(Vector128<Single> firstOp, Vector128<Single> secondOp, Vector128<Single> thirdOp, void* result, [CallerMemberName] string method = "")
        {
            Single[] inArray1 = new Single[Op1ElementCount];
            Single[] inArray2 = new Single[Op2ElementCount];
            Single[] inArray3 = new Single[Op3ElementCount];
            Single[] outArray = new Single[RetElementCount];

            Unsafe.WriteUnaligned(ref Unsafe.As<Single, byte>(ref inArray1[0]), firstOp);
            Unsafe.WriteUnaligned(ref Unsafe.As<Single, byte>(ref inArray2[0]), secondOp);
            Unsafe.WriteUnaligned(ref Unsafe.As<Single, byte>(ref inArray3[0]), thirdOp);
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Single, byte>(ref outArray[0]), ref Unsafe.AsRef<byte>(result), (uint)Unsafe.SizeOf<Vector128<Single>>());

            ValidateResult(inArray1, inArray2, inArray3, outArray, method);
        }

        private void ValidateResult(void* firstOp, void* secondOp, void* thirdOp, void* result, [CallerMemberName] string method = "")
        {
            Single[] inArray1 = new Single[Op1ElementCount];
            Single[] inArray2 = new Single[Op2ElementCount];
            Single[] inArray3 = new Single[Op3ElementCount];
            Single[] outArray = new Single[RetElementCount];

            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Single, byte>(ref inArray1[0]), ref Unsafe.AsRef<byte>(firstOp), (uint)Unsafe.SizeOf<Vector128<Single>>());
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Single, byte>(ref inArray2[0]), ref Unsafe.AsRef<byte>(secondOp), (uint)Unsafe.SizeOf<Vector128<Single>>());
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Single, byte>(ref inArray3[0]), ref Unsafe.AsRef<byte>(thirdOp), (uint)Unsafe.SizeOf<Vector128<Single>>());
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Single, byte>(ref outArray[0]), ref Unsafe.AsRef<byte>(result), (uint)Unsafe.SizeOf<Vector128<Single>>());

            ValidateResult(inArray1, inArray2, inArray3, outArray, method);
        }

        private void ValidateResult(Single[] firstOp, Single[] secondOp, Single[] thirdOp, Single[] result, [CallerMemberName] string method = "")
        {
            bool succeeded = true;

            if (((BitConverter.SingleToInt32Bits(thirdOp[0]) >> 31) & 1) == 1 ? BitConverter.SingleToInt32Bits(secondOp[0]) != BitConverter.SingleToInt32Bits(result[0]) : BitConverter.SingleToInt32Bits(firstOp[0]) != BitConverter.SingleToInt32Bits(result[0]))
            {
                succeeded = false;
            }
            else
            {
                for (var i = 1; i < RetElementCount; i++)
                {
                    if (((BitConverter.SingleToInt32Bits(thirdOp[i]) >> 31) & 1) == 1 ? BitConverter.SingleToInt32Bits(secondOp[i]) != BitConverter.SingleToInt32Bits(result[i]) : BitConverter.SingleToInt32Bits(firstOp[i]) != BitConverter.SingleToInt32Bits(result[i]))
                    {
                        succeeded = false;
                        break;
                    }
                }
            }

            if (!succeeded)
            {
                TestLibrary.TestFramework.LogInformation($"{nameof(Sse41)}.{nameof(Sse41.BlendVariable)}<Single>(Vector128<Single>, Vector128<Single>, Vector128<Single>): {method} failed:");
                TestLibrary.TestFramework.LogInformation($"   firstOp: ({string.Join(", ", firstOp)})");
                TestLibrary.TestFramework.LogInformation($"  secondOp: ({string.Join(", ", secondOp)})");
                TestLibrary.TestFramework.LogInformation($"   thirdOp: ({string.Join(", ", thirdOp)})");
                TestLibrary.TestFramework.LogInformation($"    result: ({string.Join(", ", result)})");
                TestLibrary.TestFramework.LogInformation(string.Empty);

                Succeeded = false;
            }
        }
    }
}
