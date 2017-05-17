class HomeTest extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {

        return (
        <div>
            <antd.Button onClick={e=>alert("呵呵")}>呵呵</antd.Button>

        </div>);
    }
}