/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_AMBIENCE_BLEND = 3849550482U;
        static const AkUniqueID PLAY_FOOTSTEPS_SC = 48784948U;
        static const AkUniqueID PLAY_FRIDGE_ENGINE_SFX = 2106759498U;
        static const AkUniqueID PLAY_INSANITY_BC = 803925205U;
        static const AkUniqueID PLAY_MUSICSWITCHCONTAINER = 430602500U;
        static const AkUniqueID PLAY_RANDOM_AMBIENCE_SFX = 1206854538U;
        static const AkUniqueID PLAY_STORYPEDALNOTES = 3330265446U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace FILTER_STATE
        {
            static const AkUniqueID GROUP = 1349931309U;

            namespace STATE
            {
                static const AkUniqueID FILTERED = 981609456U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID UNFILTERED = 4094838817U;
            } // namespace STATE
        } // namespace FILTER_STATE

        namespace GAMEPLAY_STATE
        {
            static const AkUniqueID GROUP = 762757699U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID STORY_SEGMENTS = 609715377U;
                static const AkUniqueID TENSION_SEGMENTS = 289869862U;
            } // namespace STATE
        } // namespace GAMEPLAY_STATE

        namespace REVERB_STATES
        {
            static const AkUniqueID GROUP = 3206201398U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID REVERB_OFF = 2902570199U;
                static const AkUniqueID REVERB_ON = 4108544803U;
            } // namespace STATE
        } // namespace REVERB_STATES

    } // namespace STATES

    namespace SWITCHES
    {
        namespace FOOTSTEPS_SG
        {
            static const AkUniqueID GROUP = 1724755371U;

            namespace SWITCH
            {
                static const AkUniqueID CARPET = 2412606308U;
                static const AkUniqueID CONCRETE = 841620460U;
                static const AkUniqueID WOOD = 2058049674U;
            } // namespace SWITCH
        } // namespace FOOTSTEPS_SG

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID AMBIENCE_PARAMETER = 1103275745U;
        static const AkUniqueID INSANITY_PARAMETER = 2526215286U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN_SOUNDBANK = 2228651116U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID REVERBTUNNER = 2659487237U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
