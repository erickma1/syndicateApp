import React, { Component } from 'react';

export class Posts extends Component {
    static displayName = Posts.name;

    constructor(props) {
        super(props);
        this.state = {
            posts: [], // Initialize 'posts' as an empty array
        };
    }

    componentDidMount() {
        // Fetch data from your ASP.NET Core controller's API endpoint.
        fetch('/api/TblPosts')
            .then((response) => response.json())
            .then((data) => this.setState({ posts: data }))
            .catch((error) => console.error('Error fetching data:', error));
    }

    render() {
        const { posts } = this.state;

        return (
            <div>
                <h1>Posts</h1>
                <table>
                    <thead>
                        <tr>
                            <th>PostCategory</th>
                            <th>PostText</th>
                            {/* Add more table headers as needed */}
                        </tr>
                    </thead>
                    <tbody>
                        {posts.map((post) => (
                            <tr key={post.idNo}>
                                <td>{post.postCategory}</td>
                                <td>{post.postText}</td>
                                {/* Add more table cells as needed */}
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        );
    }
}