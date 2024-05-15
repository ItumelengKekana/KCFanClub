import { useEffect, useState } from 'react';

import './App.css';
import MatchSchedule from './Components/MatchSchedule';
import PlayerProfile from './Components/PlayerProfile';
import MatchResults from './Components/MatchResults';
import CommentSection from './Components/CommentSection';

import logo from './assets/kc-logo.svg';
import photo from './assets/chiefs-photo.jpg';

function App() {
    const [players, setPlayer] = useState();

    useEffect(() => {
        populatePlayerData();
    }, []);

    async function populatePlayerData() {
        const response = await fetch('https://localhost:7084/api/players');
        const data = await response.json();
        setPlayer(data.result);
    }

    return (
        <div>
            <nav
                className="relative flex w-full flex-wrap items-center justify-between bg-zinc-50 py-2 shadow-dark-mild  lg:py-4">
                <div className="flex w-full flex-wrap items-center justify-between px-3">
                    <div className="ms-2">
                        <img src={ logo } className="w-32" />
                    </div>
                </div>
            </nav>
            <div>
                <img src={ photo } />
            </div>
            <MatchSchedule />
            <MatchResults />
            <div className="mt-3 mb-3">
                <h2 className="text-2xl font-semibold leading-tight text-center">Active Players</h2>
            </div>
            <div className="grid grid-cols-4 gap-4 ml-5">
                { players && players.map(player =>
                    <PlayerProfile key={ player.id } name={ player.name } position={ player.position } nationality={ player.nationality } bio={ player.bio } />
                ) }

            </div>
            <div className="mt-3 mb-3">
                <h2 className="text-2xl font-semibold leading-tight text-center">Have Your Say!</h2>
            </div>
            <CommentSection />
        </div>
    );

}

export default App;