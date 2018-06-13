﻿/* ------------------------------------------------------------------------- */
//
// Copyright (c) 2010 CubeSoft, Inc.
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
/* ------------------------------------------------------------------------- */
using Cube.Pdf.Ghostscript;
using NUnit.Framework;
using System.Collections.Generic;

namespace Cube.Pdf.Tests.Ghostscript
{
    /* --------------------------------------------------------------------- */
    ///
    /// ConverterTest
    ///
    /// <summary>
    /// Converter のテスト用クラスです。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [TestFixture]
    class ConverterTest : ConverterFixture
    {
        #region Tests

        /* ----------------------------------------------------------------- */
        ///
        /// Invoke
        ///
        /// <summary>
        /// 変換処理テストを実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCaseSource(nameof(TestCases))]
        public void Invoke(Converter cv, string srcname, string destname)
        {
            var dest = Run(cv, srcname, destname);
            Assert.That(IO.Exists(dest), Is.True);
        }

        #endregion

        #region TestCases

        /* ----------------------------------------------------------------- */
        ///
        /// TestCases
        ///
        /// <summary>
        /// テストケース一覧を取得します。
        /// </summary>
        ///
        /// <remarks>
        /// Paper の設定は入力ファイルによっては反映されない場合がある。
        /// 例えば、SampleCjk.ps を変換すると Paper の設定に関わらず常に
        /// A4 サイズで変換される。原因を要調査。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                /* --------------------------------------------------------- */
                // Orientation
                /* --------------------------------------------------------- */
                yield return TestCase(new Converter(Format.Pdf)
                {
                    Orientation = Orientation.Portrait,
                }, "Sample.ps", Orientation.Portrait);

                yield return TestCase(new Converter(Format.Pdf)
                {
                    Orientation = Orientation.UpsideDown,
                }, "Sample.ps", Orientation.UpsideDown);

                yield return TestCase(new Converter(Format.Pdf)
                {
                    Orientation = Orientation.Landscape,
                }, "Sample.ps", Orientation.Landscape);

                yield return TestCase(new Converter(Format.Pdf)
                {
                    Orientation = Orientation.Seascape,
                }, "Sample.ps", Orientation.Seascape);

                /* --------------------------------------------------------- */
                // Paper
                /* --------------------------------------------------------- */
                yield return TestCase(new Converter(Format.Pdf)
                {
                    Paper = Paper.IsoB4,
                }, "Sample.ps", Paper.IsoB4);

                yield return TestCase(new Converter(Format.Pdf)
                {
                    Paper = Paper.JisB4,
                }, "Sample.ps", Paper.JisB4);

                yield return TestCase(new Converter(Format.Pdf)
                {
                    Paper = Paper.Letter,
                }, "Sample.ps", Paper.Letter);
            }
        }

        #endregion
    }
}