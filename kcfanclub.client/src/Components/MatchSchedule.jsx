import { useEffect, useState } from 'react';

function MatchSchedule() {

    const [matches, setMatches] = useState();

    useEffect(() => {
        populateMatchData();
    }, []);

    async function populateMatchData() {
        const response = await fetch('https://localhost:7084/api/matches');
        const data = await response.json();
        setMatches(data.result);
    }

    return (
        <div className="container mx-auto px-4 sm:px-8">
            <div className="py-8">
                <div>
                    <h2 className="text-2xl font-semibold leading-tight text-center">Upcoming Matches</h2>
                </div>
                <div className="-mx-4 sm:-mx-8 px-4 sm:px-8 py-4 overflow-x-auto">
                    <div className="inline-block min-w-full shadow rounded-lg overflow-hidden">
                        <table className="min-w-full leading-normal">
                            <thead>
                                <tr>
                                    <th
                                        className="px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-center text-xs font-semibold text-gray-600 uppercase tracking-wider">
                                        Opponent
                                    </th>
                                    <th
                                        className="px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-center text-xs font-semibold text-gray-600 uppercase tracking-wider">
                                        Date
                                    </th>
                                    <th
                                        className="px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-center text-xs font-semibold text-gray-600 uppercase tracking-wider">
                                        Time
                                    </th>
                                    <th
                                        className="px-5 py-3 border-b-2 border-gray-200 bg-gray-100 text-center text-xs font-semibold text-gray-600 uppercase tracking-wider">
                                        Venue
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                { matches && matches.map(match =>
                                    <tr key={ match.id }>
                                        <td className="px-5 py-5 border-b border-gray-200 bg-white text-sm w-2/5">
                                            <div className="flex items-center">
                                                <div className="flex-shrink-0 w-10 h-10 hidden sm:table-cell">
                                                    <img className="w-full h-full rounded-full"
                                                        src="https://images.unsplash.com/photo-1601046668428-94ea13437736?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=2167&q=80"
                                                        alt="" />
                                                </div>
                                                <div className="ml-3">
                                                    <p className="text-gray-900 whitespace-no-wrap">
                                                        { match.opponent }
                                                    </p>
                                                </div>
                                            </div>
                                        </td>
                                        <td className="px-5 py-5 border-b border-gray-200 bg-white text-sm">
                                            <p className="text-gray-900 whitespace-no-wrap text-center">{ match.date }</p>
                                        </td>
                                        <td className="px-5 py-5 border-b border-gray-200 bg-white text-sm">
                                            <p className="text-gray-900 whitespace-no-wrap text-center">
                                                { match.time }
                                            </p>
                                        </td>
                                        <td className="px-5 py-5 border-b border-gray-200 bg-white text-sm w-2/5">
                                            <div className="grid justify-items-center">
                                                <div className="mr-3">
                                                    <p className="text-gray-900 whitespace-no-wrap text-right">
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