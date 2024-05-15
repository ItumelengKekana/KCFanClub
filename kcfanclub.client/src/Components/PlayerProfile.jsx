/* eslint-disable react/prop-types */


function PlayerProfile(props) {
    return (
        <div>
            <div className="max-w-xs">
                <div className="bg-white shadow-xl rounded-lg py-3">
                    <div className="photo-wrapper p-2">
                        <img className="w-32 h-32 rounded-full mx-auto" src="https://images.unsplash.com/photo-1517466787929-bc90951d0974?q=80&w=1972&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt={ props.name } />
                    </div>
                    <div className="p-2">
                        <h3 className="text-center text-xl text-gray-900 font-medium leading-8">{ props.name }</h3>
                        <div className="text-center text-gray-400 text-xs font-semibold">
                            <p>{ props.position }</p>
                        </div>
                        <div className="flex flex-col items-center">
                            <div className="px-2 py-2 text-gray-500 font-semibold">
                                Nationality
                            </div>
                            <div>
                                { props.nationality }
                            </div>
                            <div className="px-2 py-2 text-gray-500 font-semibold">
                                Bio
                            </div>
                            <div className="text-center">
                                { props.bio }
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    );
}

export default PlayerProfile;