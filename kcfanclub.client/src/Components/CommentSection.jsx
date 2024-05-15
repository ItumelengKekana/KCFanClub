import { useEffect, useState } from 'react';


function CommentSection() {
    const [posts, setPosts] = useState();
    const [name, setUsername] = useState("");
    const [comment, setComment] = useState("");

    useEffect(() => {
        populateCommentsData();
    }, []);

    async function populateCommentsData() {
        const response = await fetch('https://localhost:7084/api/comments');
        const data = await response.json();
        setPosts(data.result);
    }

    const addComment = async () => {
        const username = name.trim();
        if (username && comment) {
            const response = fetch('https://localhost:7084/api/comments', {
                method: "POST",
                mode: 'cors',
                body: JSON.stringify({
                    username,
                    comment
                }),
                headers: {
                    "Content-type": "application/json; charset=UTF-8",
                },
            });
            const data = (await response).json();
            setPosts([...posts], data);
            setUsername("");
            setComment("");
            window.location.reload();
        }
    };

    return (
        <div className="w-fullbg-white rounded-lg border p-1 md:p-3 m-10">
            <h3 className="font-semibold p-1">Discussion</h3>
            <div className="flex flex-col gap-5 m-3">


                <div>
                    { posts && posts.map(comment =>
                        <div className="flex w-full justify-between border rounded-md mb-3" key={ comment.id }>

                            <div className="p-3">
                                <div className="flex gap-3 items-center">
                                    <img src="https://avatars.githubusercontent.com/u/22263436?v=4"
                                        className="object-cover w-10 h-10 rounded-full border-2 border-emerald-400  shadow-emerald-400" />
                                    <h3 className="font-bold">
                                        { comment.username }
                                        <br />
                                        <span className="text-sm text-gray-400 font-normal">Level 1</span>
                                    </h3>
                                </div>
                                <p className="text-gray-600 mt-2">
                                    { comment.comment }
                                </p>
                            </div>


                            <div className="flex flex-col items-end gap-3 pr-3 py-3">
                                <div>
                                    <svg className="w-6 h-6 text-gray-600" xmlns="http://www.w3.org/2000/svg" fill="none"
                                        viewBox="0 0 24 24" strokeWidth="5" stroke="currentColor">
                                        <path strokeLinecap="round" strokeLinejoin="round" d="M4.5 15.75l7.5-7.5 7.5 7.5" />
                                    </svg>
                                </div>
                                <div>
                                    <svg className="w-6 h-6 text-gray-600" xmlns="http://www.w3.org/2000/svg" fill="none"
                                        viewBox="0 0 24 24" strokeWidth="5" stroke="currentColor">
                                        <path strokeLinecap="round" strokeLinejoin="round" d="M19.5 8.25l-7.5 7.5-7.5-7.5" />
                                    </svg>
                                </div>
                            </div>

                        </div>
                    ) }


                    <div className="w-full px-3 mb-2 mt-6">
                        <input type="text" className="px-2.5 py-1.5 border border-gray-400 rounded-md text-black text-sm text-lg" placeholder="Username" value={ name } onChange={ e => setUsername(e.target.value) } />
                    </div>
                    <div className="w-full px-3 mb-2 mt-6">
                        <textarea
                            className="bg-gray-100 rounded border border-gray-400 leading-normal resize-none w-full h-20 py-2 px-3 font-medium placeholder-gray-400 focus:outline-none focus:bg-white"
                            name="body" placeholder="Comment" required value={ comment } onChange={ e => setComment(e.target.value) }></textarea>
                    </div>

                    <div className="w-full flex justify-end px-3 my-3">
                        <input type="submit" className="px-2.5 py-1.5 rounded-md text-black text-sm bg-yellow-500 text-lg" value='Post Comment' onClick={ addComment } />
                    </div>
                </div>
            </div>
        </div>
    );
}
export default CommentSection;