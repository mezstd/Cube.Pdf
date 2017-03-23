﻿/* ------------------------------------------------------------------------- */
///
/// Copyright (c) 2010 CubeSoft, Inc.
/// 
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///  http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
///
/* ------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using IoEx = System.IO;

namespace Cube.Pdf.Tests
{
    /* --------------------------------------------------------------------- */
    ///
    /// DocumentResource
    /// 
    /// <summary>
    /// テストで DocumentReader を使用する際の補助クラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    class DocumentResource<TDocumentReader> : FileResource, IDisposable
        where TDocumentReader : IDocumentReader, new()
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// DocumentResource
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected DocumentResource() : base() { }

        /* ----------------------------------------------------------------- */
        ///
        /// ~DocumentResource
        ///
        /// <summary>
        /// オブジェクトを破棄します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        ~DocumentResource()
        {
            Dispose(false);
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Cache
        /// 
        /// <summary>
        /// DocumentReader オブジェクトのキャッシュ一覧を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected IDictionary<string, TDocumentReader> Cache { get; }
            = new Dictionary<string, TDocumentReader>();

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        /// 
        /// <summary>
        /// DocumentReader オブジェクトを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected TDocumentReader Create(string filename)
            => Create(filename, string.Empty);

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        /// 
        /// <summary>
        /// DocumentReader オブジェクトを生成します。
        /// </summary>
        /// 
        /// <remarks>
        /// 内部に DocumentReader のキャッシュを保持し、同じファイルに
        /// 対しては 1 回だけ読み込む事とします。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        protected TDocumentReader Create(string filename, string password)
        {
            if (!Cache.ContainsKey(filename))
            {
                var src = IoEx.Path.Combine(Examples, filename);
                var reader = new TDocumentReader();
                reader.Open(src, password);
                Cache.Add(filename, reader);
            }
            return Cache[filename];
        }

        #region IDisposable

        /* ----------------------------------------------------------------- */
        ///
        /// Dispose
        /// 
        /// <summary>
        /// オブジェクトを破棄する際に必要な終了処理を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Dispose
        /// 
        /// <summary>
        /// オブジェクトを破棄する際に必要な終了処理を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            _disposed = true;
            if (disposing)
            {
                foreach (var item in Cache) item.Value.Dispose();
                Cache.Clear();
            }
        }

        #endregion

        #endregion

        #region Fields
        private bool _disposed = false;
        #endregion
    }
}
