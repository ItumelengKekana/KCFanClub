/* eslint-disable react/no-unknown-property */

import { useEffect, useState } from 'react';

function MatchSchedule() {

    const [matches, setMatches] = useState();

    useEffect(() => {
        populateMatchData();
    }, []);

    async function populateMatchData() {
        const response = await fetch('https://localhost:7084/api/matches');
        const data = await response.json();
        setMatches(data);
    }

    return (
        <div class="container mx-auto px-4 sm:px-8">
            <div class="py-8">
                <div>
                    <h2 class="text-2xl font-semibold leading-tight text-center">Upcoming Matches</h2>
                </div>
                <div class="-mx-4 sm:-mx-8 px-4 sm:px-8 py-4 overflow-x-auto">
                    <div class="inline-block min-w-full shadow rounded-lg overflow-hidden">
                        <table class="min-w-full leading-normal">
                            <thead>
                                <tr>
                                    <th
                                        class="px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-center text-xs font-semibold text-gray-600 uppercase tracking-wider">
                                        Opponent
                                    </th>
                                    <th
                                        class="px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-center text-xs font-semibold text-gray-600 uppercase tracking-wider">
                                        Date
                                    </th>
                                    <th
                                        class="px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-center text-xs font-semibold text-gray-600 uppercase tracking-wider">
                                        Time
                                    </th>
                                    <th
                                        class="px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-center text-xs font-semibold text-gray-600 uppercase tracking-wider">
                                        Venue
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                {matches && matches.result.map(match =>
                                    <tr key={ match.id }>
                                        <td class="px-5 py-5 border-b border-gray-200 bg-white text-sm w-2/5">
                                            <div class="flex items-center">
                                                <div class="flex-shrink-0 w-10 h-10 hidden sm:table-cell">
                                                    <img class="w-full h-full rounded-full"
                                                        src="https://images.unsplash.com/photo-1601046668428-94ea13437736?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=2167&q=80"
                                                        alt="" />
                                                </div>
                                                <div class="ml-3">
                                                    <p class="text-gray-900 whitespace-no-wrap">
                                                        { match.opponent }
                                                    </p>
                                                </div>
                                            </div>
                                        </td>
                                        <td class="px-5 py-5 border-b border-gray-200 bg-white text-sm">
                                            <p class="text-gray-900 whitespace-no-wrap text-center">{ match.date }</p>
                                        </td>
                                        <td class="px-5 py-5 border-b border-gray-200 bg-white text-sm">
                                            <p class="text-gray-900 whitespace-no-wrap text-center">
                                                { match.time }
                                            </p>
                                        </td>
                                        <td class="px-5 py-5 border-b border-gray-200 bg-white text-sm w-2/5">
                                            <div class="grid justify-items-center">
                                                <div class="mr-3">
                                                    <p class="text-gray-900 whitespace-no-wrap text-right">
                                                        { match.venue }
                                                    </p>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                )
                                }
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default MatchSchedule;