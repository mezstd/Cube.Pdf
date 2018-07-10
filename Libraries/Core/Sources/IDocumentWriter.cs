﻿/* ------------------------------------------------------------------------- */
//
// Copyright (c) 2010 CubeSoft, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
/* ------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;

namespace Cube.Pdf
{
    /* --------------------------------------------------------------------- */
    ///
    /// IDocumentWriter
    ///
    /// <summary>
    /// PDF ファイルを作成、保存するためのインターフェースです。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public interface IDocumentWriter : IDisposable
    {
        /* ----------------------------------------------------------------- */
        ///
        /// Reset
        ///
        /// <summary>
        /// 初期状態にリセットします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        void Reset();

        /* ----------------------------------------------------------------- */
        ///
        /// Save
        ///
        /// <summary>
        /// 指定されたパスに PDF ファイルを保存します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        void Save(string path);

        /* ----------------------------------------------------------------- */
        ///
        /// Add
        ///
        /// <summary>
        /// ページを追加します。
        /// </summary>
        ///
        /// <param name="pages">ページ一覧</param>
        ///
        /* ----------------------------------------------------------------- */
        void Add(IEnumerable<Page> pages);

        /* ----------------------------------------------------------------- */
        ///
        /// Add
        ///
        /// <summary>
        /// ページを追加します。
        /// </summary>
        ///
        /// <param name="pages">ページ一覧</param>
        /// <param name="hint">
        /// ページの詳細情報を取得するためのオブジェクト
        /// </param>
        ///
        /* ----------------------------------------------------------------- */
        void Add(IEnumerable<Page> pages, IDocumentReader hint);

        /* ----------------------------------------------------------------- */
        ///
        /// Attach
        ///
        /// <summary>
        /// ファイルを添付します。
        /// </summary>
        ///
        /// <param name="files">添付ファイル一覧</param>
        ///
        /* ----------------------------------------------------------------- */
        void Attach(IEnumerable<Attachment> files);

        /* ----------------------------------------------------------------- */
        ///
        /// Set
        ///
        /// <summary>
        /// PDF ファイルのメタデータを設定します。
        /// </summary>
        ///
        /// <param name="metadata">メタデータ</param>
        ///
        /* ----------------------------------------------------------------- */
        void Set(Metadata metadata);

        /* ----------------------------------------------------------------- */
        ///
        /// Set
        ///
        /// <summary>
        /// 暗号化に関する情報を設定します。
        /// </summary>
        ///
        /// <param name="encryption">暗号化情報</param>
        ///
        /* ----------------------------------------------------------------- */
        void Set(Encryption encryption);
    }
}