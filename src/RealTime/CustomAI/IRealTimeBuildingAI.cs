// <copyright file="IRealTimeBuildingAI.cs" company="dymanoid">
// Copyright (c) dymanoid. All rights reserved.
// </copyright>

namespace RealTime.CustomAI
{
    using RealTime.UI;

    /// <summary>
    /// An interface for the custom logic for the private buildings.
    /// </summary>
    internal interface IRealTimeBuildingAI
    {
        /// <summary>
        /// Determines whether the building with the specified <paramref name="buildingId"/> is noise restricted
        /// (has NIMBY policy that is active on current time).
        /// </summary>
        /// <param name="buildingId">The building ID to check.</param>
        /// <param name="currentBuildingId">The ID of a building where the citizen starts their journey.
        /// Specify 0 if there is no journey in schedule.</param>
        /// <returns>
        ///   <c>true</c> if the building with the specified <paramref name="buildingId"/> has NIMBY policy
        ///   that is active on current time; otherwise, <c>false</c>.
        /// </returns>
        bool IsNoiseRestricted(ushort buildingId, ushort currentBuildingId = 0);

        /// <summary>Registers a trouble reaching the building with the specified ID.</summary>
        /// <param name="buildingId">The ID of the building where the citizen will not arrive as planned.</param>
        void RegisterReachingTrouble(ushort buildingId);

        /// <summary>
        /// Determines whether the building with the specified <paramref name="buildingId"/> is working or not
        /// </summary>
        /// <param name="buildingId">The building ID to check.</param>
        /// <returns>
        ///   <c>true</c> if the building with the specified <paramref name="buildingId"/> is working otherwise, <c>false</c>.
        /// </returns>
        bool IsBuildingWorking(ushort buildingId);

        /// <summary>
        /// Get the number of workers currently working in the specified <paramref name="buildingId"/>
        /// </summary>
        /// <param name="buildingId">The building ID to check.</param>
        /// <returns>the number of workers in the specified building</returns>
        int GetWorkersInBuilding(ushort buildingId);

        /// <summary>
        /// Get an array of workers that belong to specified <paramref name="buildingId"/>
        /// </summary>
        /// <param name="buildingId">The building ID to check.</param>
        /// <returns>an array of workers that belong to the specified building</returns>
        uint[] GetBuildingWorkForce(ushort buildingId);

        /// <summary>
        /// Determines whether the building will have weekly pickups of mail and garabge or not
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the building will have weekly pickups;
        ///   otherwise, <c>false</c>.
        /// </returns>
        bool WeeklyPickupsOnly();
    }
}
