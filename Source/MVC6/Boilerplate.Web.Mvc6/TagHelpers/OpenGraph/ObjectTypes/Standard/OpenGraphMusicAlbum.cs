﻿namespace Boilerplate.Web.Mvc.TagHelpers.OpenGraph
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    /// <summary>
    /// This object represents a music album; in other words, an ordered collection of songs from an artist or a collection of artists. An album can 
    /// comprise multiple discs. This object type is part of the Open Graph standard.
    /// See http://ogp.me/
    /// See https://developers.facebook.com/docs/reference/opengraph/object-type/music.album/
    /// </summary>
    [TargetElement(nameof(OpenGraphMusicAlbum), Attributes = nameof(Title) + "," + nameof(MainImage) + "," + nameof(SongUrls) + "," + nameof(SongDisc) + "," + nameof(SongTrack))]
    public class OpenGraphMusicAlbum : OpenGraphMetadata
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGraphMusicAlbum"/> class.
        /// </summary>
        public OpenGraphMusicAlbum() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGraphMusicAlbum"/> class.
        /// </summary>
        /// <param name="title">The title of the object as it should appear in the graph.</param>
        /// <param name="mainImage">The main image which should represent your object within the graph. This is a required property.</param>
        /// <param name="songUrls">The URL's to the pages about the songs on this album. This URL must contain profile meta tags <see cref="OpenGraphMusicSong"/>.</param>
        /// <param name="url">The canonical URL of the object, used as its ID in the graph. Leave as <c>null</c> to get the URL of the current page.</param>
        public OpenGraphMusicAlbum(string title, OpenGraphImage mainImage, IEnumerable<string> songUrls, string url = null)
            : base(title, mainImage, url)
        {
            if (songUrls == null)
            {
                throw new ArgumentNullException(nameof(songUrls));
            }

            this.SongUrls = songUrls;
            this.SongDisc = 1;
            this.SongTrack = 1;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the namespace of this open graph type.
        /// </summary>
        public override string Namespace { get { return "music: http://ogp.me/ns/music#"; } }

        /// <summary>
        /// Gets or sets the URL's to the pages about the musicians who wrote the song. This URL must contain profile meta tags <see cref="OpenGraphProfile"/>.
        /// </summary>
        public IEnumerable<string> MusicianUrls { get; set; }

        /// <summary>
        /// Gets or sets the release date of the album.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the type of the release of the album. This is a Facebook specific property and not specified by the Open Graph standard.
        /// </summary>
        public OpenGraphMusicReleaseType? ReleaseType { get; set; }

        /// <summary>
        /// Gets or sets which disc in the album the song is from.
        /// </summary>
        public int SongDisc { get; set; }

        /// <summary>
        /// Gets or sets which track in the album the song is from.
        /// </summary>
        public int SongTrack { get; set; }

        /// <summary>
        /// Gets or sets the URL's to the pages about the songs on this album. This URL must contain profile meta tags <see cref="OpenGraphMusicSong"/>.
        /// </summary>
        public IEnumerable<string> SongUrls { get; set; }

        /// <summary>
        /// Gets the type of your object. Depending on the type you specify, other properties may also be required.
        /// </summary>
        public override OpenGraphType Type { get { return OpenGraphType.MusicAlbum; } }

        #endregion

        #region Public Methods

        /// <summary>
        /// Appends a HTML-encoded string representing this instance to the <paramref name="stringBuilder"/> containing the Open Graph meta tags.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        public override void ToString(StringBuilder stringBuilder)
        {
            base.ToString(stringBuilder);

            stringBuilder.AppendMetaPropertyContentIfNotNull("music:song", this.SongUrls);
            stringBuilder.AppendMetaPropertyContent("music:song:disc", this.SongDisc);
            stringBuilder.AppendMetaPropertyContent("music:song:track", this.SongTrack);
            stringBuilder.AppendMetaPropertyContentIfNotNull("music:musician", this.MusicianUrls);
            stringBuilder.AppendMetaPropertyContentIfNotNull("music:release_date", this.ReleaseDate);

            if (this.ReleaseType.HasValue)
            {
                stringBuilder.AppendMetaPropertyContent("music:release_type", this.ReleaseType.Value.ToLowercaseString());
            }
        }

        #endregion
    }
}
