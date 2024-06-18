using TMPro;
using UnityEngine;

/// <summary>
/// オブジェクトを指定したターゲットに移動させるコンポーネント
/// </summary>
public class MoveToController : MonoBehaviour
{
    [Tooltip("移動先ターゲットとなるオブジェクト")]  // このように書くと Inspector に説明を表示できる
    [SerializeField] Transform[] _targets;
    [Tooltip("オブジェクトの移動速度")]
    [SerializeField] float _moveSpeed = 1f;
    [Tooltip("ターゲットに到達したと判断する距離（単位:メートル）")]
    [SerializeField] float _stoppingDistance = 0.05f;
    /// <summary>次のターゲットに到達するまでのタイムリミット（秒）</summary>
    [SerializeField] float _timeLimitToNextTarget = 1f;
    /// <summary>現在のターゲットのインデックス</summary>
    int _currentTargetIndex = 0;
    float _timer = 0;
    float time;

    void Update()
    {
        //MoveToTarget0();                        // 例題
         Patrol();                            // 課題1
         PatrolWithChangeTargetByTimeout();   // 課題2
        // PatrolWithChangeTargetByCollision(); // 課題3
        time += Time.deltaTime;
    }

    /// <summary>
    /// 例題: _targets[0] にアサインしたオブジェクトの位置まで移動する処理を書け。
    /// </summary>
    void MoveToTarget0()
    {
        // 自分自身とターゲットの距離を求める
        float distance = Vector2.Distance(this.transform.position, _targets[0].position);

        if (distance > _stoppingDistance)  // ターゲットに到達するまで処理する
        {
            Vector3 dir = (_targets[0].transform.position - this.transform.position).normalized * _moveSpeed; // 移動方向のベクトルを求める
            this.transform.Translate(dir * Time.deltaTime); // Update の中で移動する場合は、Time.deltaTime をかけることによりどの環境でも同じ速さで移動させることができる
        }
    }

    /// <summary>
    /// 課題1:
    /// _targets[] にアサインした任意の数 n のオブジェクトを巡回移動する処理を書け。
    /// 例）
    /// _targets[0] に到達したら次は _targets[1] に向かう
    /// _targets[1] に到達したら次は _targets[2] に向かう
    /// _targets[2] に到達したら次は _targets[3] に向かう
    /// ...
    /// _targets[n] に到達したら次は _targets[0] に向かう
    /// （以下、繰り返す）
    /// </summary>
    void Patrol()
    {

        float distance = Vector2.Distance(this.transform.position, _targets[_currentTargetIndex].position);

        if (distance > _stoppingDistance)
        {
            Vector3 dir = (_targets[_currentTargetIndex].transform.position - this.transform.position).normalized * _moveSpeed;
            this.transform.Translate(dir * Time.deltaTime);
        }
        else
        {
            _currentTargetIndex++;
        }
        if(_currentTargetIndex == 4)
        {
            _currentTargetIndex = 0;
        }
    }

    /// <summary>
    /// 課題2:
    /// _targets[] にアサインした任意の数 n のオブジェクトを巡回移動する処理を書け。
    /// ただし、制限時間をメンバ変数として設定し、制限時間内に次のオブジェクトに到達しなかった場合は配列の次の要素のオブジェクトに移動先を切り替えよ。
    /// 例）
    /// _targets[1] に制限時間内に到達しなかったら、その時点で _targets[2] に向かう
    /// _targets[2] に制限時間内に到達したら、_targets[3] に向かう
    /// </summary>
    void PatrolWithChangeTargetByTimeout()
    {

        float distance = Vector2.Distance(this.transform.position, _targets[_currentTargetIndex].position);
        _timer += Time.deltaTime;

        if (distance < _stoppingDistance || _timer > _timeLimitToNextTarget)
        {
            if(_currentTargetIndex < 3)
            {
                _currentTargetIndex++;
            }
            else
            {
                _currentTargetIndex = 0;
            }
            _timer = 0;
        }
        else
        {
            Vector3 dir = (_targets[_currentTargetIndex].transform.position - this.transform.position).normalized * _moveSpeed;
            this.transform.Translate(dir * Time.deltaTime);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_currentTargetIndex < 3)
        {
            _currentTargetIndex++;
        }
        else
        {
            _currentTargetIndex = 0;
        }
    }
    /// <summary>
    /// 課題3:
    /// m_targets[] にアサインした任意の数 n のオブジェクトを巡回移動する処理を書け。
    /// ただし、移動中に壁にぶつかった場合は、配列の次の要素のオブジェクトに移動先を切り替えよ。
    /// 例）
    /// m_targets[1] に移動中に何かにぶつかったら、その時点で m_targets[2] に向かう
    /// </summary>
    void PatrolWithChangeTargetByCollision()
    {
        Patrol();
    }
}
