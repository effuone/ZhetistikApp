import React, {Component} from 'react';
import {Table} from 'react-bootstrap'

export class Candidate extends Component
{
    constructor(props)
    {
        super(props);
        this.state={candidates:[]}
    }
    refreshList()
    {
        fetch(process.env.REACT_APP_API+'candidates/')
        .then((response) => {
            return response.json();
          })
        .then(data=>{
            this.setState({candidates:data});
        });
    }
    componentDidMount(){
        this.refreshList();
    }
    componentDidUpdate(){
        this.refreshList();
    }
    render(){
        const {candidates} = this.state;
        return(
            <div>
                <Table className="mt-4" striped bordered hover size='sm'>
                    <thead>
                        <tr>
                        <td>CandidateID</td>
                        <td>FirstName</td>
                        <td>LastName</td>
                        <td>Birthday</td>
                        <td>Email</td>
                        <td>PhoneNumber</td>
                        </tr>
                    </thead>
                    <tbody>
                        {candidates.map(can=>
                            <tr key={can.CandidateID}>
                                <td>{can.CandidateID}</td>
                                <td>{can.FirstName}</td>
                                <td>{can.LastName}</td>
                                <td>{can.Birthday}</td>
                                <td>{can.Email}</td>
                                <td>{can.PhoneNumber}</td>
                                <td>Edit / Delete</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </div>
        )
    }
}