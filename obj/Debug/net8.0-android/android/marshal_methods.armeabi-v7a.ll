; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [310 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [614 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 67
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 66
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 107
	i32 32687329, ; 3: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 230
	i32 34715100, ; 4: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 264
	i32 34839235, ; 5: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 47
	i32 39485524, ; 6: System.Net.WebSockets.dll => 0x25a8054 => 79
	i32 42639949, ; 7: System.Threading.Thread => 0x28aa24d => 144
	i32 66541672, ; 8: System.Diagnostics.StackTrace => 0x3f75868 => 29
	i32 67008169, ; 9: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 305
	i32 68219467, ; 10: System.Security.Cryptography.Primitives => 0x410f24b => 123
	i32 72070932, ; 11: Microsoft.Maui.Graphics.dll => 0x44bb714 => 187
	i32 82292897, ; 12: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 101
	i32 101534019, ; 13: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 248
	i32 117431740, ; 14: System.Runtime.InteropServices => 0x6ffddbc => 106
	i32 120558881, ; 15: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 248
	i32 122350210, ; 16: System.Threading.Channels.dll => 0x74aea82 => 138
	i32 134690465, ; 17: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 268
	i32 142721839, ; 18: System.Net.WebHeaderCollection => 0x881c32f => 76
	i32 149972175, ; 19: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 123
	i32 159306688, ; 20: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 21: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 204
	i32 176265551, ; 22: System.ServiceProcess => 0xa81994f => 131
	i32 182336117, ; 23: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 250
	i32 184328833, ; 24: System.ValueTuple.dll => 0xafca281 => 150
	i32 195452805, ; 25: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 302
	i32 199333315, ; 26: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 303
	i32 205061960, ; 27: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 28: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 202
	i32 220171995, ; 29: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 230216969, ; 30: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 224
	i32 230752869, ; 31: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 32: System.Linq.Parallel => 0xdcb05c4 => 58
	i32 231814094, ; 33: System.Globalization => 0xdd133ce => 41
	i32 246610117, ; 34: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 90
	i32 261689757, ; 35: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 207
	i32 276479776, ; 36: System.Threading.Timer.dll => 0x107abf20 => 146
	i32 278686392, ; 37: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 226
	i32 280482487, ; 38: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 223
	i32 280992041, ; 39: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 274
	i32 291076382, ; 40: System.IO.Pipes.AccessControl.dll => 0x1159791e => 53
	i32 298918909, ; 41: System.Net.Ping.dll => 0x11d123fd => 68
	i32 317674968, ; 42: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 302
	i32 318968648, ; 43: Xamarin.AndroidX.Activity.dll => 0x13031348 => 193
	i32 321597661, ; 44: System.Numerics => 0x132b30dd => 82
	i32 336156722, ; 45: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 287
	i32 342366114, ; 46: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 225
	i32 356389973, ; 47: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 286
	i32 360082299, ; 48: System.ServiceModel.Web => 0x15766b7b => 130
	i32 367780167, ; 49: System.IO.Pipes => 0x15ebe147 => 54
	i32 374914964, ; 50: System.Transactions.Local => 0x1658bf94 => 148
	i32 375677976, ; 51: System.Net.ServicePoint.dll => 0x16646418 => 73
	i32 379916513, ; 52: System.Threading.Thread.dll => 0x16a510e1 => 144
	i32 385762202, ; 53: System.Memory.dll => 0x16fe439a => 61
	i32 392610295, ; 54: System.Threading.ThreadPool.dll => 0x1766c1f7 => 145
	i32 395744057, ; 55: _Microsoft.Android.Resource.Designer => 0x17969339 => 306
	i32 403441872, ; 56: WindowsBase => 0x180c08d0 => 164
	i32 435591531, ; 57: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 298
	i32 441335492, ; 58: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 208
	i32 442565967, ; 59: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 60: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 221
	i32 451504562, ; 61: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 124
	i32 456227837, ; 62: System.Web.HttpUtility.dll => 0x1b317bfd => 151
	i32 459347974, ; 63: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 112
	i32 465846621, ; 64: mscorlib => 0x1bc4415d => 165
	i32 469710990, ; 65: System.dll => 0x1bff388e => 163
	i32 476175157, ; 66: TBRAppMobile.dll => 0x1c61db35 => 0
	i32 476646585, ; 67: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 223
	i32 486930444, ; 68: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 236
	i32 498788369, ; 69: System.ObjectModel => 0x1dbae811 => 83
	i32 500358224, ; 70: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 285
	i32 503918385, ; 71: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 279
	i32 513247710, ; 72: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 181
	i32 526420162, ; 73: System.Transactions.dll => 0x1f6088c2 => 149
	i32 527452488, ; 74: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 268
	i32 530272170, ; 75: System.Linq.Queryable => 0x1f9b4faa => 59
	i32 539058512, ; 76: Microsoft.Extensions.Logging => 0x20216150 => 177
	i32 540030774, ; 77: System.IO.FileSystem.dll => 0x20303736 => 50
	i32 545304856, ; 78: System.Runtime.Extensions => 0x2080b118 => 102
	i32 546455878, ; 79: System.Runtime.Serialization.Xml => 0x20924146 => 113
	i32 549171840, ; 80: System.Globalization.Calendars => 0x20bbb280 => 39
	i32 557405415, ; 81: Jsr305Binding => 0x213954e7 => 261
	i32 569601784, ; 82: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 259
	i32 577335427, ; 83: System.Security.Cryptography.Cng => 0x22697083 => 119
	i32 592146354, ; 84: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 293
	i32 601371474, ; 85: System.IO.IsolatedStorage.dll => 0x23d83352 => 51
	i32 605376203, ; 86: System.IO.Compression.FileSystem => 0x24154ecb => 43
	i32 613668793, ; 87: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 118
	i32 627609679, ; 88: Xamarin.AndroidX.CustomView => 0x2568904f => 213
	i32 627931235, ; 89: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 291
	i32 639843206, ; 90: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 219
	i32 643868501, ; 91: System.Net => 0x2660a755 => 80
	i32 662205335, ; 92: System.Text.Encodings.Web.dll => 0x27787397 => 135
	i32 663517072, ; 93: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 255
	i32 666292255, ; 94: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 200
	i32 672442732, ; 95: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 96: System.Net.Security => 0x28bdabca => 72
	i32 688181140, ; 97: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 273
	i32 690569205, ; 98: System.Xml.Linq.dll => 0x29293ff5 => 154
	i32 691348768, ; 99: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 270
	i32 693804605, ; 100: System.Windows => 0x295a9e3d => 153
	i32 699345723, ; 101: System.Reflection.Emit => 0x29af2b3b => 91
	i32 700284507, ; 102: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 265
	i32 700358131, ; 103: System.IO.Compression.ZipFile => 0x29be9df3 => 44
	i32 706645707, ; 104: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 288
	i32 709557578, ; 105: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 276
	i32 720511267, ; 106: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 269
	i32 722857257, ; 107: System.Runtime.Loader.dll => 0x2b15ed29 => 108
	i32 735137430, ; 108: System.Security.SecureString.dll => 0x2bd14e96 => 128
	i32 752232764, ; 109: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 110: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 190
	i32 759454413, ; 111: System.Net.Requests => 0x2d445acd => 71
	i32 762598435, ; 112: System.IO.Pipes.dll => 0x2d745423 => 54
	i32 775507847, ; 113: System.IO.Compression => 0x2e394f87 => 45
	i32 777317022, ; 114: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 297
	i32 789151979, ; 115: Microsoft.Extensions.Options => 0x2f0980eb => 180
	i32 790371945, ; 116: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 214
	i32 804715423, ; 117: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 118: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 228
	i32 823281589, ; 119: System.Private.Uri.dll => 0x311247b5 => 85
	i32 830298997, ; 120: System.IO.Compression.Brotli => 0x317d5b75 => 42
	i32 832635846, ; 121: System.Xml.XPath.dll => 0x31a103c6 => 159
	i32 834051424, ; 122: System.Net.Quic => 0x31b69d60 => 70
	i32 843511501, ; 123: Xamarin.AndroidX.Print => 0x3246f6cd => 241
	i32 873119928, ; 124: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 125: System.Globalization.dll => 0x34505120 => 41
	i32 878954865, ; 126: System.Net.Http.Json => 0x3463c971 => 62
	i32 904024072, ; 127: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 911108515, ; 128: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 52
	i32 926902833, ; 129: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 300
	i32 928116545, ; 130: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 264
	i32 952186615, ; 131: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 104
	i32 956575887, ; 132: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 269
	i32 966729478, ; 133: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 262
	i32 967690846, ; 134: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 225
	i32 975236339, ; 135: System.Diagnostics.Tracing => 0x3a20ecf3 => 33
	i32 975874589, ; 136: System.Xml.XDocument => 0x3a2aaa1d => 157
	i32 986514023, ; 137: System.Private.DataContractSerialization.dll => 0x3acd0267 => 84
	i32 987214855, ; 138: System.Diagnostics.Tools => 0x3ad7b407 => 31
	i32 992768348, ; 139: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 140: System.IO.FileSystem => 0x3b45fb35 => 50
	i32 1001831731, ; 141: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 55
	i32 1012816738, ; 142: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 245
	i32 1019214401, ; 143: System.Drawing => 0x3cbffa41 => 35
	i32 1028951442, ; 144: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 176
	i32 1029334545, ; 145: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 275
	i32 1031528504, ; 146: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 263
	i32 1035644815, ; 147: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 198
	i32 1036536393, ; 148: System.Drawing.Primitives.dll => 0x3dc84a49 => 34
	i32 1044663988, ; 149: System.Linq.Expressions.dll => 0x3e444eb4 => 57
	i32 1052210849, ; 150: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 232
	i32 1067306892, ; 151: GoogleGson => 0x3f9dcf8c => 172
	i32 1082857460, ; 152: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 153: Xamarin.Kotlin.StdLib => 0x409e66d8 => 266
	i32 1098259244, ; 154: System => 0x41761b2c => 163
	i32 1118262833, ; 155: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 288
	i32 1121599056, ; 156: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 231
	i32 1127624469, ; 157: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 179
	i32 1149092582, ; 158: Xamarin.AndroidX.Window => 0x447dc2e6 => 258
	i32 1168523401, ; 159: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 294
	i32 1170634674, ; 160: System.Web.dll => 0x45c677b2 => 152
	i32 1175144683, ; 161: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 254
	i32 1178241025, ; 162: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 239
	i32 1203215381, ; 163: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 292
	i32 1204270330, ; 164: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 200
	i32 1208641965, ; 165: System.Diagnostics.Process => 0x480a69ad => 28
	i32 1219128291, ; 166: System.IO.IsolatedStorage => 0x48aa6be3 => 51
	i32 1234928153, ; 167: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 290
	i32 1243150071, ; 168: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 259
	i32 1253011324, ; 169: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 170: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 274
	i32 1264511973, ; 171: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 249
	i32 1267360935, ; 172: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 253
	i32 1273260888, ; 173: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 205
	i32 1275534314, ; 174: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 270
	i32 1278448581, ; 175: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 197
	i32 1293217323, ; 176: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 216
	i32 1305607842, ; 177: TBRAppMobile => 0x4dd1fea2 => 0
	i32 1309188875, ; 178: System.Private.DataContractSerialization => 0x4e08a30b => 84
	i32 1322716291, ; 179: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 258
	i32 1324164729, ; 180: System.Linq => 0x4eed2679 => 60
	i32 1335329327, ; 181: System.Runtime.Serialization.Json.dll => 0x4f97822f => 111
	i32 1364015309, ; 182: System.IO => 0x514d38cd => 56
	i32 1373134921, ; 183: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 304
	i32 1376866003, ; 184: Xamarin.AndroidX.SavedState => 0x52114ed3 => 245
	i32 1379779777, ; 185: System.Resources.ResourceManager => 0x523dc4c1 => 98
	i32 1402170036, ; 186: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 187: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 209
	i32 1408764838, ; 188: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 110
	i32 1411638395, ; 189: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 100
	i32 1422545099, ; 190: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 101
	i32 1430672901, ; 191: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 272
	i32 1434145427, ; 192: System.Runtime.Handles => 0x557b5293 => 103
	i32 1435222561, ; 193: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 262
	i32 1439761251, ; 194: System.Net.Quic.dll => 0x55d10363 => 70
	i32 1452070440, ; 195: System.Formats.Asn1.dll => 0x568cd628 => 37
	i32 1453312822, ; 196: System.Diagnostics.Tools.dll => 0x569fcb36 => 31
	i32 1457743152, ; 197: System.Runtime.Extensions.dll => 0x56e36530 => 102
	i32 1458022317, ; 198: System.Net.Security.dll => 0x56e7a7ad => 72
	i32 1461004990, ; 199: es\Microsoft.Maui.Controls.resources => 0x57152abe => 278
	i32 1461234159, ; 200: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 201: System.Security.Cryptography.OpenSsl => 0x57201017 => 122
	i32 1462112819, ; 202: System.IO.Compression.dll => 0x57261233 => 45
	i32 1469204771, ; 203: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 199
	i32 1470490898, ; 204: Microsoft.Extensions.Primitives => 0x57a5e912 => 181
	i32 1479771757, ; 205: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 206: System.IO.Compression.Brotli.dll => 0x583e844f => 42
	i32 1487239319, ; 207: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 208: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 246
	i32 1493001747, ; 209: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 282
	i32 1514721132, ; 210: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 277
	i32 1536373174, ; 211: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 30
	i32 1543031311, ; 212: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 137
	i32 1543355203, ; 213: System.Reflection.Emit.dll => 0x5bfdbb43 => 91
	i32 1550322496, ; 214: System.Reflection.Extensions.dll => 0x5c680b40 => 92
	i32 1551623176, ; 215: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 297
	i32 1565862583, ; 216: System.IO.FileSystem.Primitives => 0x5d552ab7 => 48
	i32 1566207040, ; 217: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 140
	i32 1573704789, ; 218: System.Runtime.Serialization.Json => 0x5dccd455 => 111
	i32 1580037396, ; 219: System.Threading.Overlapped => 0x5e2d7514 => 139
	i32 1582372066, ; 220: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 215
	i32 1592978981, ; 221: System.Runtime.Serialization.dll => 0x5ef2ee25 => 114
	i32 1597949149, ; 222: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 263
	i32 1601112923, ; 223: System.Xml.Serialization => 0x5f6f0b5b => 156
	i32 1604827217, ; 224: System.Net.WebClient => 0x5fa7b851 => 75
	i32 1618516317, ; 225: System.Net.WebSockets.Client.dll => 0x6078995d => 78
	i32 1622152042, ; 226: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 235
	i32 1622358360, ; 227: System.Dynamic.Runtime => 0x60b33958 => 36
	i32 1624863272, ; 228: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 257
	i32 1635184631, ; 229: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 219
	i32 1636350590, ; 230: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 212
	i32 1639515021, ; 231: System.Net.Http.dll => 0x61b9038d => 63
	i32 1639986890, ; 232: System.Text.RegularExpressions => 0x61c036ca => 137
	i32 1641389582, ; 233: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1657153582, ; 234: System.Runtime => 0x62c6282e => 115
	i32 1658241508, ; 235: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 251
	i32 1658251792, ; 236: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 260
	i32 1670060433, ; 237: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 207
	i32 1675553242, ; 238: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 47
	i32 1677501392, ; 239: System.Net.Primitives.dll => 0x63fca3d0 => 69
	i32 1678508291, ; 240: System.Net.WebSockets => 0x640c0103 => 79
	i32 1679769178, ; 241: System.Security.Cryptography => 0x641f3e5a => 125
	i32 1691477237, ; 242: System.Reflection.Metadata => 0x64d1e4f5 => 93
	i32 1696967625, ; 243: System.Security.Cryptography.Csp => 0x6525abc9 => 120
	i32 1698840827, ; 244: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 267
	i32 1701541528, ; 245: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1720223769, ; 246: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 228
	i32 1726116996, ; 247: System.Reflection.dll => 0x66e27484 => 96
	i32 1728033016, ; 248: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 27
	i32 1729485958, ; 249: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 203
	i32 1736233607, ; 250: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 295
	i32 1743415430, ; 251: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 273
	i32 1744735666, ; 252: System.Transactions.Local.dll => 0x67fe8db2 => 148
	i32 1746316138, ; 253: Mono.Android.Export => 0x6816ab6a => 168
	i32 1750313021, ; 254: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 255: System.Resources.Reader.dll => 0x68cc9d1e => 97
	i32 1763938596, ; 256: System.Diagnostics.TraceSource.dll => 0x69239124 => 32
	i32 1765942094, ; 257: System.Reflection.Extensions => 0x6942234e => 92
	i32 1766324549, ; 258: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 250
	i32 1770582343, ; 259: Microsoft.Extensions.Logging.dll => 0x6988f147 => 177
	i32 1776026572, ; 260: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 261: System.Globalization.Extensions.dll => 0x69ec0683 => 40
	i32 1780572499, ; 262: Mono.Android.Runtime.dll => 0x6a216153 => 169
	i32 1782862114, ; 263: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 289
	i32 1788241197, ; 264: Xamarin.AndroidX.Fragment => 0x6a96652d => 221
	i32 1793755602, ; 265: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 281
	i32 1808609942, ; 266: Xamarin.AndroidX.Loader => 0x6bcd3296 => 235
	i32 1813058853, ; 267: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 266
	i32 1813201214, ; 268: Xamarin.Google.Android.Material => 0x6c13413e => 260
	i32 1818569960, ; 269: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 240
	i32 1818787751, ; 270: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 271: System.Text.Encoding.Extensions => 0x6cbab720 => 133
	i32 1824722060, ; 272: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 110
	i32 1828688058, ; 273: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 178
	i32 1842015223, ; 274: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 301
	i32 1847515442, ; 275: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 190
	i32 1853025655, ; 276: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 298
	i32 1858542181, ; 277: System.Linq.Expressions => 0x6ec71a65 => 57
	i32 1870277092, ; 278: System.Reflection.Primitives => 0x6f7a29e4 => 94
	i32 1875935024, ; 279: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 280
	i32 1879696579, ; 280: System.Formats.Tar.dll => 0x7009e4c3 => 38
	i32 1885316902, ; 281: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 201
	i32 1888955245, ; 282: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 283: System.Reflection.Metadata.dll => 0x70a66bdd => 93
	i32 1898237753, ; 284: System.Reflection.DispatchProxy => 0x7124cf39 => 88
	i32 1900610850, ; 285: System.Resources.ResourceManager.dll => 0x71490522 => 98
	i32 1910275211, ; 286: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1939592360, ; 287: System.Private.Xml.Linq => 0x739bd4a8 => 86
	i32 1956758971, ; 288: System.Resources.Writer => 0x74a1c5bb => 99
	i32 1961813231, ; 289: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 247
	i32 1968388702, ; 290: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 173
	i32 1983156543, ; 291: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 267
	i32 1985761444, ; 292: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 192
	i32 2003115576, ; 293: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 277
	i32 2011961780, ; 294: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2019465201, ; 295: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 232
	i32 2025202353, ; 296: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 272
	i32 2031763787, ; 297: Xamarin.Android.Glide => 0x791a414b => 189
	i32 2045470958, ; 298: System.Private.Xml => 0x79eb68ee => 87
	i32 2055257422, ; 299: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 227
	i32 2060060697, ; 300: System.Windows.dll => 0x7aca0819 => 153
	i32 2066184531, ; 301: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 276
	i32 2070888862, ; 302: System.Diagnostics.TraceSource => 0x7b6f419e => 32
	i32 2079903147, ; 303: System.Runtime.dll => 0x7bf8cdab => 115
	i32 2090596640, ; 304: System.Numerics.Vectors => 0x7c9bf920 => 81
	i32 2127167465, ; 305: System.Console => 0x7ec9ffe9 => 20
	i32 2142473426, ; 306: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 307: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 161
	i32 2146852085, ; 308: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 309: Microsoft.Maui => 0x80bd55ad => 185
	i32 2169148018, ; 310: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 284
	i32 2181898931, ; 311: Microsoft.Extensions.Options.dll => 0x820d22b3 => 180
	i32 2192057212, ; 312: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 178
	i32 2193016926, ; 313: System.ObjectModel.dll => 0x82b6c85e => 83
	i32 2201107256, ; 314: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 271
	i32 2201231467, ; 315: System.Net.Http => 0x8334206b => 63
	i32 2207618523, ; 316: it\Microsoft.Maui.Controls.resources => 0x839595db => 286
	i32 2217644978, ; 317: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 254
	i32 2222056684, ; 318: System.Threading.Tasks.Parallel => 0x8471e4ec => 142
	i32 2244775296, ; 319: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 236
	i32 2252106437, ; 320: System.Xml.Serialization.dll => 0x863c6ac5 => 156
	i32 2256313426, ; 321: System.Globalization.Extensions => 0x867c9c52 => 40
	i32 2265110946, ; 322: System.Security.AccessControl.dll => 0x8702d9a2 => 116
	i32 2266799131, ; 323: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 174
	i32 2267999099, ; 324: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 191
	i32 2270573516, ; 325: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 280
	i32 2279755925, ; 326: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 243
	i32 2293034957, ; 327: System.ServiceModel.Web.dll => 0x88acefcd => 130
	i32 2295906218, ; 328: System.Net.Sockets => 0x88d8bfaa => 74
	i32 2298471582, ; 329: System.Net.Mail => 0x88ffe49e => 65
	i32 2303942373, ; 330: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 290
	i32 2305521784, ; 331: System.Private.CoreLib.dll => 0x896b7878 => 171
	i32 2315684594, ; 332: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 195
	i32 2320631194, ; 333: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 142
	i32 2340441535, ; 334: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 105
	i32 2344264397, ; 335: System.ValueTuple => 0x8bbaa2cd => 150
	i32 2353062107, ; 336: System.Net.Primitives => 0x8c40e0db => 69
	i32 2368005991, ; 337: System.Xml.ReaderWriter.dll => 0x8d24e767 => 155
	i32 2371007202, ; 338: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 173
	i32 2378619854, ; 339: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 120
	i32 2383496789, ; 340: System.Security.Principal.Windows.dll => 0x8e114655 => 126
	i32 2395872292, ; 341: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 285
	i32 2401565422, ; 342: System.Web.HttpUtility => 0x8f24faee => 151
	i32 2403452196, ; 343: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 218
	i32 2421380589, ; 344: System.Threading.Tasks.Dataflow => 0x905355ed => 140
	i32 2423080555, ; 345: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 205
	i32 2427813419, ; 346: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 282
	i32 2435356389, ; 347: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 348: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2454642406, ; 349: System.Text.Encoding.dll => 0x924edee6 => 134
	i32 2458678730, ; 350: System.Net.Sockets.dll => 0x928c75ca => 74
	i32 2459001652, ; 351: System.Linq.Parallel.dll => 0x92916334 => 58
	i32 2465532216, ; 352: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 208
	i32 2471841756, ; 353: netstandard.dll => 0x93554fdc => 166
	i32 2475788418, ; 354: Java.Interop.dll => 0x93918882 => 167
	i32 2480646305, ; 355: Microsoft.Maui.Controls => 0x93dba8a1 => 183
	i32 2483903535, ; 356: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 357: System.Net.ServicePoint => 0x94147f61 => 73
	i32 2490993605, ; 358: System.AppContext.dll => 0x94798bc5 => 6
	i32 2501346920, ; 359: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2505896520, ; 360: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 230
	i32 2522472828, ; 361: Xamarin.Android.Glide.dll => 0x9659e17c => 189
	i32 2538310050, ; 362: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 90
	i32 2550873716, ; 363: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 283
	i32 2562349572, ; 364: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 365: System.Text.Encodings.Web => 0x9930ee42 => 135
	i32 2581783588, ; 366: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 231
	i32 2581819634, ; 367: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 253
	i32 2585220780, ; 368: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 133
	i32 2585805581, ; 369: System.Net.Ping => 0x9a20430d => 68
	i32 2589602615, ; 370: System.Threading.ThreadPool => 0x9a5a3337 => 145
	i32 2593496499, ; 371: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 292
	i32 2605712449, ; 372: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 271
	i32 2615233544, ; 373: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 222
	i32 2616218305, ; 374: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 179
	i32 2617129537, ; 375: System.Private.Xml.dll => 0x9bfe3a41 => 87
	i32 2618712057, ; 376: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 95
	i32 2620871830, ; 377: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 212
	i32 2624644809, ; 378: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 217
	i32 2626831493, ; 379: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 287
	i32 2627185994, ; 380: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 30
	i32 2629843544, ; 381: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 44
	i32 2633051222, ; 382: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 226
	i32 2663391936, ; 383: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 191
	i32 2663698177, ; 384: System.Runtime.Loader => 0x9ec4cf01 => 108
	i32 2664396074, ; 385: System.Xml.XDocument.dll => 0x9ecf752a => 157
	i32 2665622720, ; 386: System.Drawing.Primitives => 0x9ee22cc0 => 34
	i32 2676780864, ; 387: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 388: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 113
	i32 2693849962, ; 389: System.IO.dll => 0xa090e36a => 56
	i32 2701096212, ; 390: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 251
	i32 2715334215, ; 391: System.Threading.Tasks.dll => 0xa1d8b647 => 143
	i32 2717744543, ; 392: System.Security.Claims => 0xa1fd7d9f => 117
	i32 2719963679, ; 393: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 119
	i32 2724373263, ; 394: System.Runtime.Numerics.dll => 0xa262a30f => 109
	i32 2732626843, ; 395: Xamarin.AndroidX.Activity => 0xa2e0939b => 193
	i32 2735172069, ; 396: System.Threading.Channels => 0xa30769e5 => 138
	i32 2737747696, ; 397: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 199
	i32 2740948882, ; 398: System.IO.Pipes.AccessControl => 0xa35f8f92 => 53
	i32 2748088231, ; 399: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 104
	i32 2752995522, ; 400: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 293
	i32 2758225723, ; 401: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 184
	i32 2764765095, ; 402: Microsoft.Maui.dll => 0xa4caf7a7 => 185
	i32 2765824710, ; 403: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 132
	i32 2770495804, ; 404: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 265
	i32 2778768386, ; 405: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 256
	i32 2779977773, ; 406: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 244
	i32 2785988530, ; 407: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 299
	i32 2788224221, ; 408: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 222
	i32 2801831435, ; 409: Microsoft.Maui.Graphics => 0xa7008e0b => 187
	i32 2803228030, ; 410: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 158
	i32 2806116107, ; 411: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 278
	i32 2810250172, ; 412: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 209
	i32 2819470561, ; 413: System.Xml.dll => 0xa80db4e1 => 162
	i32 2821205001, ; 414: System.ServiceProcess.dll => 0xa8282c09 => 131
	i32 2821294376, ; 415: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 244
	i32 2824502124, ; 416: System.Xml.XmlDocument => 0xa85a7b6c => 160
	i32 2831556043, ; 417: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 291
	i32 2838993487, ; 418: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 233
	i32 2849599387, ; 419: System.Threading.Overlapped.dll => 0xa9d96f9b => 139
	i32 2853208004, ; 420: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 256
	i32 2855708567, ; 421: Xamarin.AndroidX.Transition => 0xaa36a797 => 252
	i32 2861098320, ; 422: Mono.Android.Export.dll => 0xaa88e550 => 168
	i32 2861189240, ; 423: Microsoft.Maui.Essentials => 0xaa8a4878 => 186
	i32 2870099610, ; 424: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 194
	i32 2875164099, ; 425: Jsr305Binding.dll => 0xab5f85c3 => 261
	i32 2875220617, ; 426: System.Globalization.Calendars.dll => 0xab606289 => 39
	i32 2884993177, ; 427: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 220
	i32 2887636118, ; 428: System.Net.dll => 0xac1dd496 => 80
	i32 2899753641, ; 429: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 55
	i32 2900621748, ; 430: System.Dynamic.Runtime.dll => 0xace3f9b4 => 36
	i32 2901442782, ; 431: System.Reflection => 0xacf080de => 96
	i32 2905242038, ; 432: mscorlib.dll => 0xad2a79b6 => 165
	i32 2909740682, ; 433: System.Private.CoreLib => 0xad6f1e8a => 171
	i32 2916838712, ; 434: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 257
	i32 2919462931, ; 435: System.Numerics.Vectors.dll => 0xae037813 => 81
	i32 2921128767, ; 436: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 196
	i32 2936416060, ; 437: System.Resources.Reader => 0xaf06273c => 97
	i32 2940926066, ; 438: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 29
	i32 2942453041, ; 439: System.Xml.XPath.XDocument => 0xaf624531 => 158
	i32 2959614098, ; 440: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 441: System.Security.Principal.Windows => 0xb0ed41f3 => 126
	i32 2972252294, ; 442: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 118
	i32 2978675010, ; 443: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 216
	i32 2987532451, ; 444: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 247
	i32 2996846495, ; 445: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 229
	i32 3016983068, ; 446: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 249
	i32 3023353419, ; 447: WindowsBase.dll => 0xb434b64b => 164
	i32 3024354802, ; 448: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 224
	i32 3038032645, ; 449: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 306
	i32 3056245963, ; 450: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 246
	i32 3057625584, ; 451: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 237
	i32 3059408633, ; 452: Mono.Android.Runtime => 0xb65adef9 => 169
	i32 3059793426, ; 453: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3075834255, ; 454: System.Threading.Tasks => 0xb755818f => 143
	i32 3077302341, ; 455: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 284
	i32 3090735792, ; 456: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 124
	i32 3099732863, ; 457: System.Security.Claims.dll => 0xb8c22b7f => 117
	i32 3103600923, ; 458: System.Formats.Asn1 => 0xb8fd311b => 37
	i32 3111772706, ; 459: System.Runtime.Serialization => 0xb979e222 => 114
	i32 3121463068, ; 460: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 46
	i32 3124832203, ; 461: System.Threading.Tasks.Extensions => 0xba4127cb => 141
	i32 3132293585, ; 462: System.Security.AccessControl => 0xbab301d1 => 116
	i32 3147165239, ; 463: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 33
	i32 3148237826, ; 464: GoogleGson.dll => 0xbba64c02 => 172
	i32 3159123045, ; 465: System.Reflection.Primitives.dll => 0xbc4c6465 => 94
	i32 3160747431, ; 466: System.IO.MemoryMappedFiles => 0xbc652da7 => 52
	i32 3178803400, ; 467: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 238
	i32 3192346100, ; 468: System.Security.SecureString => 0xbe4755f4 => 128
	i32 3193515020, ; 469: System.Web => 0xbe592c0c => 152
	i32 3204380047, ; 470: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 471: System.Xml.XmlDocument.dll => 0xbf506931 => 160
	i32 3211777861, ; 472: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 215
	i32 3220365878, ; 473: System.Threading => 0xbff2e236 => 147
	i32 3226221578, ; 474: System.Runtime.Handles.dll => 0xc04c3c0a => 103
	i32 3251039220, ; 475: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 88
	i32 3258312781, ; 476: Xamarin.AndroidX.CardView => 0xc235e84d => 203
	i32 3265493905, ; 477: System.Linq.Queryable.dll => 0xc2a37b91 => 59
	i32 3265893370, ; 478: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 141
	i32 3277815716, ; 479: System.Resources.Writer.dll => 0xc35f7fa4 => 99
	i32 3279906254, ; 480: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 481: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3290767353, ; 482: System.Security.Cryptography.Encoding => 0xc4251ff9 => 121
	i32 3299363146, ; 483: System.Text.Encoding => 0xc4a8494a => 134
	i32 3303498502, ; 484: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 27
	i32 3305363605, ; 485: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 279
	i32 3316684772, ; 486: System.Net.Requests.dll => 0xc5b097e4 => 71
	i32 3317135071, ; 487: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 213
	i32 3317144872, ; 488: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 489: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 201
	i32 3345895724, ; 490: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 242
	i32 3346324047, ; 491: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 239
	i32 3357674450, ; 492: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 296
	i32 3358260929, ; 493: System.Text.Json => 0xc82afec1 => 136
	i32 3362336904, ; 494: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 194
	i32 3362522851, ; 495: Xamarin.AndroidX.Core => 0xc86c06e3 => 210
	i32 3366347497, ; 496: Java.Interop => 0xc8a662e9 => 167
	i32 3374999561, ; 497: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 243
	i32 3381016424, ; 498: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 275
	i32 3395150330, ; 499: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 100
	i32 3403906625, ; 500: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 122
	i32 3405233483, ; 501: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 214
	i32 3428513518, ; 502: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 175
	i32 3429136800, ; 503: System.Xml => 0xcc6479a0 => 162
	i32 3430777524, ; 504: netstandard => 0xcc7d82b4 => 166
	i32 3441283291, ; 505: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 217
	i32 3445260447, ; 506: System.Formats.Tar => 0xcd5a809f => 38
	i32 3452344032, ; 507: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 182
	i32 3463511458, ; 508: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 283
	i32 3471940407, ; 509: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 510: Mono.Android => 0xcf3163e6 => 170
	i32 3479583265, ; 511: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 296
	i32 3484440000, ; 512: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 295
	i32 3485117614, ; 513: System.Text.Json.dll => 0xcfbaacae => 136
	i32 3486566296, ; 514: System.Transactions => 0xcfd0c798 => 149
	i32 3493954962, ; 515: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 206
	i32 3509114376, ; 516: System.Xml.Linq => 0xd128d608 => 154
	i32 3515174580, ; 517: System.Security.dll => 0xd1854eb4 => 129
	i32 3530912306, ; 518: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 519: System.Net.HttpListener => 0xd2ff69f1 => 64
	i32 3560100363, ; 520: System.Threading.Timer => 0xd432d20b => 146
	i32 3570554715, ; 521: System.IO.FileSystem.AccessControl => 0xd4d2575b => 46
	i32 3580758918, ; 522: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 303
	i32 3597029428, ; 523: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 192
	i32 3598340787, ; 524: System.Net.WebSockets.Client => 0xd67a52b3 => 78
	i32 3608519521, ; 525: System.Linq.dll => 0xd715a361 => 60
	i32 3624195450, ; 526: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 105
	i32 3627220390, ; 527: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 241
	i32 3633644679, ; 528: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 196
	i32 3638274909, ; 529: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 48
	i32 3641597786, ; 530: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 227
	i32 3643446276, ; 531: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 300
	i32 3643854240, ; 532: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 238
	i32 3645089577, ; 533: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3657292374, ; 534: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 174
	i32 3660523487, ; 535: System.Net.NetworkInformation => 0xda2f27df => 67
	i32 3672681054, ; 536: Mono.Android.dll => 0xdae8aa5e => 170
	i32 3682565725, ; 537: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 202
	i32 3684561358, ; 538: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 206
	i32 3697841164, ; 539: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 305
	i32 3700866549, ; 540: System.Net.WebProxy.dll => 0xdc96bdf5 => 77
	i32 3706696989, ; 541: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 211
	i32 3716563718, ; 542: System.Runtime.Intrinsics => 0xdd864306 => 107
	i32 3718780102, ; 543: Xamarin.AndroidX.Annotation => 0xdda814c6 => 195
	i32 3724971120, ; 544: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 237
	i32 3732100267, ; 545: System.Net.NameResolution => 0xde7354ab => 66
	i32 3737834244, ; 546: System.Net.Http.Json.dll => 0xdecad304 => 62
	i32 3748608112, ; 547: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 188
	i32 3751444290, ; 548: System.Xml.XPath => 0xdf9a7f42 => 159
	i32 3786282454, ; 549: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 204
	i32 3792276235, ; 550: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3800979733, ; 551: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 182
	i32 3802395368, ; 552: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3819260425, ; 553: System.Net.WebProxy => 0xe3a54a09 => 77
	i32 3823082795, ; 554: System.Security.Cryptography.dll => 0xe3df9d2b => 125
	i32 3829621856, ; 555: System.Numerics.dll => 0xe4436460 => 82
	i32 3841636137, ; 556: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 176
	i32 3844307129, ; 557: System.Net.Mail.dll => 0xe52378b9 => 65
	i32 3849253459, ; 558: System.Runtime.InteropServices.dll => 0xe56ef253 => 106
	i32 3870376305, ; 559: System.Net.HttpListener.dll => 0xe6b14171 => 64
	i32 3873536506, ; 560: System.Security.Principal => 0xe6e179fa => 127
	i32 3875112723, ; 561: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 121
	i32 3885497537, ; 562: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 76
	i32 3885922214, ; 563: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 252
	i32 3888767677, ; 564: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 242
	i32 3889960447, ; 565: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 304
	i32 3896106733, ; 566: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 567: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 210
	i32 3901907137, ; 568: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920810846, ; 569: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 43
	i32 3921031405, ; 570: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 255
	i32 3928044579, ; 571: System.Xml.ReaderWriter => 0xea213423 => 155
	i32 3930554604, ; 572: System.Security.Principal.dll => 0xea4780ec => 127
	i32 3931092270, ; 573: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 240
	i32 3945713374, ; 574: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 575: System.Text.Encoding.CodePages => 0xebac8bfe => 132
	i32 3955647286, ; 576: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 198
	i32 3959773229, ; 577: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 229
	i32 3980434154, ; 578: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 299
	i32 3987592930, ; 579: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 281
	i32 4003436829, ; 580: System.Diagnostics.Process.dll => 0xee9f991d => 28
	i32 4015948917, ; 581: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 197
	i32 4025784931, ; 582: System.Memory => 0xeff49a63 => 61
	i32 4046471985, ; 583: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 184
	i32 4054681211, ; 584: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 89
	i32 4068434129, ; 585: System.Private.Xml.Linq.dll => 0xf27f60d1 => 86
	i32 4073602200, ; 586: System.Threading.dll => 0xf2ce3c98 => 147
	i32 4094352644, ; 587: Microsoft.Maui.Essentials.dll => 0xf40add04 => 186
	i32 4099507663, ; 588: System.Drawing.dll => 0xf45985cf => 35
	i32 4100113165, ; 589: System.Private.Uri => 0xf462c30d => 85
	i32 4101593132, ; 590: Xamarin.AndroidX.Emoji2 => 0xf479582c => 218
	i32 4102112229, ; 591: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 294
	i32 4125707920, ; 592: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 289
	i32 4126470640, ; 593: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 175
	i32 4127667938, ; 594: System.IO.FileSystem.Watcher => 0xf60736e2 => 49
	i32 4130442656, ; 595: System.AppContext => 0xf6318da0 => 6
	i32 4147896353, ; 596: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 89
	i32 4150914736, ; 597: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 301
	i32 4151237749, ; 598: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 599: System.Xml.XmlSerializer => 0xf7e95c85 => 161
	i32 4161255271, ; 600: System.Reflection.TypeExtensions => 0xf807b767 => 95
	i32 4164802419, ; 601: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 49
	i32 4181436372, ; 602: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 112
	i32 4182413190, ; 603: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 234
	i32 4185676441, ; 604: System.Security => 0xf97c5a99 => 129
	i32 4196529839, ; 605: System.Net.WebClient.dll => 0xfa21f6af => 75
	i32 4213026141, ; 606: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 188
	i32 4256097574, ; 607: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 211
	i32 4258378803, ; 608: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 233
	i32 4260525087, ; 609: System.Buffers => 0xfdf2741f => 7
	i32 4271975918, ; 610: Microsoft.Maui.Controls.dll => 0xfea12dee => 183
	i32 4274976490, ; 611: System.Runtime.Numerics => 0xfecef6ea => 109
	i32 4292120959, ; 612: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 234
	i32 4294763496 ; 613: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 220
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [614 x i32] [
	i32 67, ; 0
	i32 66, ; 1
	i32 107, ; 2
	i32 230, ; 3
	i32 264, ; 4
	i32 47, ; 5
	i32 79, ; 6
	i32 144, ; 7
	i32 29, ; 8
	i32 305, ; 9
	i32 123, ; 10
	i32 187, ; 11
	i32 101, ; 12
	i32 248, ; 13
	i32 106, ; 14
	i32 248, ; 15
	i32 138, ; 16
	i32 268, ; 17
	i32 76, ; 18
	i32 123, ; 19
	i32 13, ; 20
	i32 204, ; 21
	i32 131, ; 22
	i32 250, ; 23
	i32 150, ; 24
	i32 302, ; 25
	i32 303, ; 26
	i32 18, ; 27
	i32 202, ; 28
	i32 26, ; 29
	i32 224, ; 30
	i32 1, ; 31
	i32 58, ; 32
	i32 41, ; 33
	i32 90, ; 34
	i32 207, ; 35
	i32 146, ; 36
	i32 226, ; 37
	i32 223, ; 38
	i32 274, ; 39
	i32 53, ; 40
	i32 68, ; 41
	i32 302, ; 42
	i32 193, ; 43
	i32 82, ; 44
	i32 287, ; 45
	i32 225, ; 46
	i32 286, ; 47
	i32 130, ; 48
	i32 54, ; 49
	i32 148, ; 50
	i32 73, ; 51
	i32 144, ; 52
	i32 61, ; 53
	i32 145, ; 54
	i32 306, ; 55
	i32 164, ; 56
	i32 298, ; 57
	i32 208, ; 58
	i32 12, ; 59
	i32 221, ; 60
	i32 124, ; 61
	i32 151, ; 62
	i32 112, ; 63
	i32 165, ; 64
	i32 163, ; 65
	i32 0, ; 66
	i32 223, ; 67
	i32 236, ; 68
	i32 83, ; 69
	i32 285, ; 70
	i32 279, ; 71
	i32 181, ; 72
	i32 149, ; 73
	i32 268, ; 74
	i32 59, ; 75
	i32 177, ; 76
	i32 50, ; 77
	i32 102, ; 78
	i32 113, ; 79
	i32 39, ; 80
	i32 261, ; 81
	i32 259, ; 82
	i32 119, ; 83
	i32 293, ; 84
	i32 51, ; 85
	i32 43, ; 86
	i32 118, ; 87
	i32 213, ; 88
	i32 291, ; 89
	i32 219, ; 90
	i32 80, ; 91
	i32 135, ; 92
	i32 255, ; 93
	i32 200, ; 94
	i32 8, ; 95
	i32 72, ; 96
	i32 273, ; 97
	i32 154, ; 98
	i32 270, ; 99
	i32 153, ; 100
	i32 91, ; 101
	i32 265, ; 102
	i32 44, ; 103
	i32 288, ; 104
	i32 276, ; 105
	i32 269, ; 106
	i32 108, ; 107
	i32 128, ; 108
	i32 25, ; 109
	i32 190, ; 110
	i32 71, ; 111
	i32 54, ; 112
	i32 45, ; 113
	i32 297, ; 114
	i32 180, ; 115
	i32 214, ; 116
	i32 22, ; 117
	i32 228, ; 118
	i32 85, ; 119
	i32 42, ; 120
	i32 159, ; 121
	i32 70, ; 122
	i32 241, ; 123
	i32 3, ; 124
	i32 41, ; 125
	i32 62, ; 126
	i32 16, ; 127
	i32 52, ; 128
	i32 300, ; 129
	i32 264, ; 130
	i32 104, ; 131
	i32 269, ; 132
	i32 262, ; 133
	i32 225, ; 134
	i32 33, ; 135
	i32 157, ; 136
	i32 84, ; 137
	i32 31, ; 138
	i32 12, ; 139
	i32 50, ; 140
	i32 55, ; 141
	i32 245, ; 142
	i32 35, ; 143
	i32 176, ; 144
	i32 275, ; 145
	i32 263, ; 146
	i32 198, ; 147
	i32 34, ; 148
	i32 57, ; 149
	i32 232, ; 150
	i32 172, ; 151
	i32 17, ; 152
	i32 266, ; 153
	i32 163, ; 154
	i32 288, ; 155
	i32 231, ; 156
	i32 179, ; 157
	i32 258, ; 158
	i32 294, ; 159
	i32 152, ; 160
	i32 254, ; 161
	i32 239, ; 162
	i32 292, ; 163
	i32 200, ; 164
	i32 28, ; 165
	i32 51, ; 166
	i32 290, ; 167
	i32 259, ; 168
	i32 5, ; 169
	i32 274, ; 170
	i32 249, ; 171
	i32 253, ; 172
	i32 205, ; 173
	i32 270, ; 174
	i32 197, ; 175
	i32 216, ; 176
	i32 0, ; 177
	i32 84, ; 178
	i32 258, ; 179
	i32 60, ; 180
	i32 111, ; 181
	i32 56, ; 182
	i32 304, ; 183
	i32 245, ; 184
	i32 98, ; 185
	i32 19, ; 186
	i32 209, ; 187
	i32 110, ; 188
	i32 100, ; 189
	i32 101, ; 190
	i32 272, ; 191
	i32 103, ; 192
	i32 262, ; 193
	i32 70, ; 194
	i32 37, ; 195
	i32 31, ; 196
	i32 102, ; 197
	i32 72, ; 198
	i32 278, ; 199
	i32 9, ; 200
	i32 122, ; 201
	i32 45, ; 202
	i32 199, ; 203
	i32 181, ; 204
	i32 9, ; 205
	i32 42, ; 206
	i32 4, ; 207
	i32 246, ; 208
	i32 282, ; 209
	i32 277, ; 210
	i32 30, ; 211
	i32 137, ; 212
	i32 91, ; 213
	i32 92, ; 214
	i32 297, ; 215
	i32 48, ; 216
	i32 140, ; 217
	i32 111, ; 218
	i32 139, ; 219
	i32 215, ; 220
	i32 114, ; 221
	i32 263, ; 222
	i32 156, ; 223
	i32 75, ; 224
	i32 78, ; 225
	i32 235, ; 226
	i32 36, ; 227
	i32 257, ; 228
	i32 219, ; 229
	i32 212, ; 230
	i32 63, ; 231
	i32 137, ; 232
	i32 15, ; 233
	i32 115, ; 234
	i32 251, ; 235
	i32 260, ; 236
	i32 207, ; 237
	i32 47, ; 238
	i32 69, ; 239
	i32 79, ; 240
	i32 125, ; 241
	i32 93, ; 242
	i32 120, ; 243
	i32 267, ; 244
	i32 26, ; 245
	i32 228, ; 246
	i32 96, ; 247
	i32 27, ; 248
	i32 203, ; 249
	i32 295, ; 250
	i32 273, ; 251
	i32 148, ; 252
	i32 168, ; 253
	i32 4, ; 254
	i32 97, ; 255
	i32 32, ; 256
	i32 92, ; 257
	i32 250, ; 258
	i32 177, ; 259
	i32 21, ; 260
	i32 40, ; 261
	i32 169, ; 262
	i32 289, ; 263
	i32 221, ; 264
	i32 281, ; 265
	i32 235, ; 266
	i32 266, ; 267
	i32 260, ; 268
	i32 240, ; 269
	i32 2, ; 270
	i32 133, ; 271
	i32 110, ; 272
	i32 178, ; 273
	i32 301, ; 274
	i32 190, ; 275
	i32 298, ; 276
	i32 57, ; 277
	i32 94, ; 278
	i32 280, ; 279
	i32 38, ; 280
	i32 201, ; 281
	i32 25, ; 282
	i32 93, ; 283
	i32 88, ; 284
	i32 98, ; 285
	i32 10, ; 286
	i32 86, ; 287
	i32 99, ; 288
	i32 247, ; 289
	i32 173, ; 290
	i32 267, ; 291
	i32 192, ; 292
	i32 277, ; 293
	i32 7, ; 294
	i32 232, ; 295
	i32 272, ; 296
	i32 189, ; 297
	i32 87, ; 298
	i32 227, ; 299
	i32 153, ; 300
	i32 276, ; 301
	i32 32, ; 302
	i32 115, ; 303
	i32 81, ; 304
	i32 20, ; 305
	i32 11, ; 306
	i32 161, ; 307
	i32 3, ; 308
	i32 185, ; 309
	i32 284, ; 310
	i32 180, ; 311
	i32 178, ; 312
	i32 83, ; 313
	i32 271, ; 314
	i32 63, ; 315
	i32 286, ; 316
	i32 254, ; 317
	i32 142, ; 318
	i32 236, ; 319
	i32 156, ; 320
	i32 40, ; 321
	i32 116, ; 322
	i32 174, ; 323
	i32 191, ; 324
	i32 280, ; 325
	i32 243, ; 326
	i32 130, ; 327
	i32 74, ; 328
	i32 65, ; 329
	i32 290, ; 330
	i32 171, ; 331
	i32 195, ; 332
	i32 142, ; 333
	i32 105, ; 334
	i32 150, ; 335
	i32 69, ; 336
	i32 155, ; 337
	i32 173, ; 338
	i32 120, ; 339
	i32 126, ; 340
	i32 285, ; 341
	i32 151, ; 342
	i32 218, ; 343
	i32 140, ; 344
	i32 205, ; 345
	i32 282, ; 346
	i32 20, ; 347
	i32 14, ; 348
	i32 134, ; 349
	i32 74, ; 350
	i32 58, ; 351
	i32 208, ; 352
	i32 166, ; 353
	i32 167, ; 354
	i32 183, ; 355
	i32 15, ; 356
	i32 73, ; 357
	i32 6, ; 358
	i32 23, ; 359
	i32 230, ; 360
	i32 189, ; 361
	i32 90, ; 362
	i32 283, ; 363
	i32 1, ; 364
	i32 135, ; 365
	i32 231, ; 366
	i32 253, ; 367
	i32 133, ; 368
	i32 68, ; 369
	i32 145, ; 370
	i32 292, ; 371
	i32 271, ; 372
	i32 222, ; 373
	i32 179, ; 374
	i32 87, ; 375
	i32 95, ; 376
	i32 212, ; 377
	i32 217, ; 378
	i32 287, ; 379
	i32 30, ; 380
	i32 44, ; 381
	i32 226, ; 382
	i32 191, ; 383
	i32 108, ; 384
	i32 157, ; 385
	i32 34, ; 386
	i32 22, ; 387
	i32 113, ; 388
	i32 56, ; 389
	i32 251, ; 390
	i32 143, ; 391
	i32 117, ; 392
	i32 119, ; 393
	i32 109, ; 394
	i32 193, ; 395
	i32 138, ; 396
	i32 199, ; 397
	i32 53, ; 398
	i32 104, ; 399
	i32 293, ; 400
	i32 184, ; 401
	i32 185, ; 402
	i32 132, ; 403
	i32 265, ; 404
	i32 256, ; 405
	i32 244, ; 406
	i32 299, ; 407
	i32 222, ; 408
	i32 187, ; 409
	i32 158, ; 410
	i32 278, ; 411
	i32 209, ; 412
	i32 162, ; 413
	i32 131, ; 414
	i32 244, ; 415
	i32 160, ; 416
	i32 291, ; 417
	i32 233, ; 418
	i32 139, ; 419
	i32 256, ; 420
	i32 252, ; 421
	i32 168, ; 422
	i32 186, ; 423
	i32 194, ; 424
	i32 261, ; 425
	i32 39, ; 426
	i32 220, ; 427
	i32 80, ; 428
	i32 55, ; 429
	i32 36, ; 430
	i32 96, ; 431
	i32 165, ; 432
	i32 171, ; 433
	i32 257, ; 434
	i32 81, ; 435
	i32 196, ; 436
	i32 97, ; 437
	i32 29, ; 438
	i32 158, ; 439
	i32 18, ; 440
	i32 126, ; 441
	i32 118, ; 442
	i32 216, ; 443
	i32 247, ; 444
	i32 229, ; 445
	i32 249, ; 446
	i32 164, ; 447
	i32 224, ; 448
	i32 306, ; 449
	i32 246, ; 450
	i32 237, ; 451
	i32 169, ; 452
	i32 16, ; 453
	i32 143, ; 454
	i32 284, ; 455
	i32 124, ; 456
	i32 117, ; 457
	i32 37, ; 458
	i32 114, ; 459
	i32 46, ; 460
	i32 141, ; 461
	i32 116, ; 462
	i32 33, ; 463
	i32 172, ; 464
	i32 94, ; 465
	i32 52, ; 466
	i32 238, ; 467
	i32 128, ; 468
	i32 152, ; 469
	i32 24, ; 470
	i32 160, ; 471
	i32 215, ; 472
	i32 147, ; 473
	i32 103, ; 474
	i32 88, ; 475
	i32 203, ; 476
	i32 59, ; 477
	i32 141, ; 478
	i32 99, ; 479
	i32 5, ; 480
	i32 13, ; 481
	i32 121, ; 482
	i32 134, ; 483
	i32 27, ; 484
	i32 279, ; 485
	i32 71, ; 486
	i32 213, ; 487
	i32 24, ; 488
	i32 201, ; 489
	i32 242, ; 490
	i32 239, ; 491
	i32 296, ; 492
	i32 136, ; 493
	i32 194, ; 494
	i32 210, ; 495
	i32 167, ; 496
	i32 243, ; 497
	i32 275, ; 498
	i32 100, ; 499
	i32 122, ; 500
	i32 214, ; 501
	i32 175, ; 502
	i32 162, ; 503
	i32 166, ; 504
	i32 217, ; 505
	i32 38, ; 506
	i32 182, ; 507
	i32 283, ; 508
	i32 17, ; 509
	i32 170, ; 510
	i32 296, ; 511
	i32 295, ; 512
	i32 136, ; 513
	i32 149, ; 514
	i32 206, ; 515
	i32 154, ; 516
	i32 129, ; 517
	i32 19, ; 518
	i32 64, ; 519
	i32 146, ; 520
	i32 46, ; 521
	i32 303, ; 522
	i32 192, ; 523
	i32 78, ; 524
	i32 60, ; 525
	i32 105, ; 526
	i32 241, ; 527
	i32 196, ; 528
	i32 48, ; 529
	i32 227, ; 530
	i32 300, ; 531
	i32 238, ; 532
	i32 14, ; 533
	i32 174, ; 534
	i32 67, ; 535
	i32 170, ; 536
	i32 202, ; 537
	i32 206, ; 538
	i32 305, ; 539
	i32 77, ; 540
	i32 211, ; 541
	i32 107, ; 542
	i32 195, ; 543
	i32 237, ; 544
	i32 66, ; 545
	i32 62, ; 546
	i32 188, ; 547
	i32 159, ; 548
	i32 204, ; 549
	i32 10, ; 550
	i32 182, ; 551
	i32 11, ; 552
	i32 77, ; 553
	i32 125, ; 554
	i32 82, ; 555
	i32 176, ; 556
	i32 65, ; 557
	i32 106, ; 558
	i32 64, ; 559
	i32 127, ; 560
	i32 121, ; 561
	i32 76, ; 562
	i32 252, ; 563
	i32 242, ; 564
	i32 304, ; 565
	i32 8, ; 566
	i32 210, ; 567
	i32 2, ; 568
	i32 43, ; 569
	i32 255, ; 570
	i32 155, ; 571
	i32 127, ; 572
	i32 240, ; 573
	i32 23, ; 574
	i32 132, ; 575
	i32 198, ; 576
	i32 229, ; 577
	i32 299, ; 578
	i32 281, ; 579
	i32 28, ; 580
	i32 197, ; 581
	i32 61, ; 582
	i32 184, ; 583
	i32 89, ; 584
	i32 86, ; 585
	i32 147, ; 586
	i32 186, ; 587
	i32 35, ; 588
	i32 85, ; 589
	i32 218, ; 590
	i32 294, ; 591
	i32 289, ; 592
	i32 175, ; 593
	i32 49, ; 594
	i32 6, ; 595
	i32 89, ; 596
	i32 301, ; 597
	i32 21, ; 598
	i32 161, ; 599
	i32 95, ; 600
	i32 49, ; 601
	i32 112, ; 602
	i32 234, ; 603
	i32 129, ; 604
	i32 75, ; 605
	i32 188, ; 606
	i32 211, ; 607
	i32 233, ; 608
	i32 7, ; 609
	i32 183, ; 610
	i32 109, ; 611
	i32 234, ; 612
	i32 220 ; 613
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.4xx @ 82d8938cf80f6d5fa6c28529ddfbdb753d805ab4"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
