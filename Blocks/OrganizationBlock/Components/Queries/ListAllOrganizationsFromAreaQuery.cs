// ListAllOrganizationsFromAreaQuery.cs
//
// Author:
//       Sales Alencar <lopesdealencar@gmail.com>
//
// Copyright (c) 2018 MIT
//
using System;
using System.Linq.Expressions;
using Dharma.OrganizationBlock.Models;

namespace Dharma.OrganizationBlock.Components.Queries
{
	internal class ListAllOrganizationsFromAreaQuery : OrganizationBaseQuery
	{
		private double _degree => (_latitude >= -51.0 && _latitude <= 51.0) ? 111.2483 : 110.5743;
		private readonly double _latitude;
		private readonly double _longitude;
		private readonly double _radius;

		private double _minLatitude;
		private double _maxLatitude;

		private double _minLongitude;
		private double _maxLongitude;

		/// <summary>
		/// Initializes a new instance of the ListAllOrganizationsFromAreaQuery class
		/// </summary>
		/// <param name="lat">Latitude.</param>
		/// <param name="lon">Longitude.</param>
		/// <param name="radius">Radius in KM.</param>
		public ListAllOrganizationsFromAreaQuery(double lat, double lon, int radius)
		{
			_latitude = lat;
			_longitude = lon;
			_radius = radius;

			CalculateMinAndMaxLatitudes();
			CalculateMinAndMaxLongitudes();
		}

		private void CalculateMinAndMaxLatitudes()
		{
			_minLatitude = _latitude - (_radius / _degree);
			_maxLatitude = _latitude + (_radius / _degree);
		}

		private void CalculateMinAndMaxLongitudes()
		{
			_minLongitude = _longitude - (_radius / (_degree * Math.Cos(_latitude)));
			_maxLongitude = _longitude + (_radius / (_degree * Math.Cos(_latitude)));
		}

		protected override Expression<Func<OrganizationModel, bool>> _filter => (t => t.Active && 
		                                                                         (t.Address.Latitude <= _maxLatitude && t.Address.Latitude >= _minLatitude) && 
		                                                                         (t.Address.Longitude <= _maxLongitude && t.Address.Longitude >= _minLongitude));
	}
}
