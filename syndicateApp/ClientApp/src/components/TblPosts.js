import React, { Component } from 'react';

export class TblPosts extends Component {
    static displayName = TblPosts.name;
    constructor(props) {
        super(props);
        this.state = {
            posts: [],
            loading: true,
        };
    }

    componentDidMount() {
        this.populatePostsData();
    }

    renderPostsTable(posts) {
        return (
            <table className='table table-striped' aria-labelledby='tabelLabel'>
                <thead>
                    <tr>
                        <th>IdNo</th>
                        <th>PostCategory</th>
                        <th>PostText</th>
                        {/* Add more table headers for other properties if needed */}
                    </tr>
                </thead>
                <tbody>
                    {posts.map(post => (
                        <tr key={post.id}>
                            <td>{post.id}</td>
                            <td>{post.name}</td>
                            <td>{post.email}</td>
                            {/* Add more table data cells for other properties if needed */}
                        </tr>
                    ))}
                </tbody>
            </table>
        );
    }

    render() {
        const { posts, loading } = this.state;

        let contents = loading ? (
            <p>
                <em>Loading...</em>
            </p>
        ) : (
            this.renderPostsTable(posts)
        );

        return (
            <div>
                <h1 id='tabelLabel'>Posts</h1>
                {contents}
            </div>
        );
    }

    async populatePostsData() {
        try {
            const response = await fetch('https://jsonplaceholder.typicode.com/users'); // Replace with your actual API endpoint
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            const data = await response.json();
            this.setState({ posts: data, loading: false });
        } catch (error) {
            console.error(error);
            this.setState({ loading: false });
        }
    }
}

