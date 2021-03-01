import React, { Component, ChangeEvent } from 'react';
import { connect } from 'react-redux';
import { IAppState } from '../../store/store';
import { Col, Container, Row, Table } from 'react-bootstrap';
import { IExpenseSummary } from '../../models/expenses/expenseSummary';
import { IExpense, IExpenseSearchOptions } from '../../models/expenses/expense';
import { ExpenseDataProvider } from '../../api/v1/expenseDataProvider';
import { Months } from '../../constants/calendar';
import moment from 'moment';
import { Chart } from "react-google-charts";

interface IDashboardProps {    
    dispatch: any;
}

interface IDashboardPageState {
    expenseSummary: IExpenseSummary | null;
    recentExpenses : IExpense[];
    chartData: any[];
}

class DashboardPage extends Component<IDashboardProps, IDashboardPageState> {
    readonly _expenseDataProvider: ExpenseDataProvider;
    readonly _date: Date = new Date();
    
    constructor(props: IDashboardProps){
        super(props);

        this.state = {
            expenseSummary: null,
            recentExpenses: [],
            chartData: []
        };

        this._expenseDataProvider = new ExpenseDataProvider();
    }
    
    componentDidMount(){
        this._expenseDataProvider
            .getExpenseSummaryAsync(this._date.getMonth() + 1)
            .then(result => {
                if(result.errors.length > 0){
                    alert(result.errors[0].message);
                }
                else{
                    this.setState({ expenseSummary: result.result }, this.updateChartData);
                }
            });
            
        this._expenseDataProvider
            .searchExpensesAsync({
                page: 1,
                pageSize: 15,
                dateFrom: new Date(this._date.getFullYear(), this._date.getMonth(), 1),
                dateTo: new Date(this._date.getFullYear(), this._date.getMonth(), 31)
            } as IExpenseSearchOptions)
            .then(result => {
                if(result.errors.length > 0){
                    alert(result.errors[0].message);
                }
                else{
                    this.setState({ recentExpenses: result.result });
                }
            });
    }

    updateChartData(){
        var data: any[] = [['Expense Type', 'Amount']];
        this.state.expenseSummary?.expenseTypes.forEach(e => data.push([e.expenseTypeName, e.totalAmount]));

        this.setState({chartData: data});
    }

    renderExpenseBody(){
        if(this.state.recentExpenses?.length > 0)
            return (
                this.state.recentExpenses.map((expense, index) => 
                    <tr>
                        <td>{expense.expenseTypeName}</td>
                        <td className="d-flex justify-content-end">{expense.amount}</td>
                        <td >{moment(expense.date).format('LL')}</td>
                    </tr>
                )
            );

        return (
            <tr>
                <td colSpan={3}>No recent expenses</td>
            </tr>
        );
    }

    render() {
		return (
			<Container>
                <Row>
                    <Col>
                        <h2>{Months[this._date.getMonth()]} - {this._date.getFullYear()}</h2>
                    </Col>
                </Row>
                <Row>
                    <Col sm={12} md={6} lg={8}>
                        <Chart
                            height={"400px"}
                            chartType="PieChart"
                            loader={<div>Loading Chart</div>}
                            data={this.state.chartData}
                            options={{
                                title: 'Expenses',
                            }}
                            rootProps={{ 'data-testid': '1' }}
                        />
                    </Col>
                    <Col className="d-none d-lg-flex justify-content-center align-items-center">
                        <div className="bg-danger text-white p-3 w-75 bold border d-flex justify-content-center align-items-center flex-column">
                            <h3>Top Expense</h3>
                            <h5>{this.state.expenseSummary?.topExpense.expenseTypeName}</h5>
                            <p>Php. {this.state.expenseSummary?.topExpense.totalAmount}</p>
                        </div>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <h4>Most Recent Expenses</h4>
                        <Table responsive={"md"}>
                            <thead>
                                <tr>
                                    <th>Expense Type</th>
                                    <th>Amount</th>
                                    <th>Date</th>
                                </tr>
                            </thead>
                            <tbody>
                                {this.renderExpenseBody()}
                            </tbody>
                        </Table>
                    </Col>
                </Row>
			</Container>
		);
	}
}

const mapStateToProps = (store: IAppState) => {
	return { };
}

const mapDispatchToProps = (dispatch: any) => {
    return { dispatch };
}

export default connect(mapStateToProps, mapDispatchToProps)(DashboardPage);
