// VanillaEvent.cs

namespace RealTime.Events
{
    using RealTime.GameConnection;
    using RealTime.Simulation;

    /// <summary>A class for the default game city event.</summary>
    /// <seealso cref="CityEventBase"/>
    internal sealed class VanillaEvent : CityEventBase
    {
        private readonly float duration;
        private readonly float ticketPrice;
        private readonly IEventManagerConnection eventManager;

        /// <summary>Initializes a new instance of the <see cref="VanillaEvent"/> class.</summary>
        /// <param name="id">The event ID.</param>
        /// <param name="duration">The city event duration in hours.</param>
        /// <param name="ticketPrice">The event ticket price.</param>
        /// <param name="eventManager">An <see cref="IEventManagerConnection"/> reference.</param>
        public VanillaEvent(ushort id, float duration, float ticketPrice, IEventManagerConnection eventManager)
        {
            this.duration = duration;
            this.ticketPrice = ticketPrice;
            EventId = id;
            this.eventManager = eventManager ?? throw new System.ArgumentNullException(nameof(eventManager));
        }

        /// <summary>Gets the vanilla event ID.</summary>
        public ushort EventId { get; }

        /// <summary>
        /// Gets the event color.
        /// </summary>
        public override EventColor Color => eventManager.GetEventColor(EventId);

        /// <summary>Accepts an event attendee with specified properties.</summary>
        /// <param name="age">The attendee age.</param>
        /// <param name="gender">The attendee gender.</param>
        /// <param name="education">The attendee education.</param>
        /// <param name="wealth">The attendee wealth.</param>
        /// <param name="wellbeing">The attendee wellbeing.</param>
        /// <param name="happiness">The attendee happiness.</param>
        /// <param name="randomizer">A reference to the game's randomizer.</param>
        /// <returns>
        /// <c>true</c> if the event attendee with specified properties is accepted and can attend
        /// this city event; otherwise, <c>false</c>.
        /// </returns>
        public override bool TryAcceptAttendee(
            Citizen.AgeGroup age,
            Citizen.Gender gender,
            Citizen.Education education,
            Citizen.Wealth wealth,
            Citizen.Wellbeing wellbeing,
            Citizen.Happiness happiness,
            IRandomizer randomizer) => ticketPrice <= GetCitizenBudgetForEvent(wealth, randomizer);

        /// <summary>Calculates the city event duration.</summary>
        /// <returns>This city event duration in hours.</returns>
        protected override float GetDuration() => duration;
    }
}
